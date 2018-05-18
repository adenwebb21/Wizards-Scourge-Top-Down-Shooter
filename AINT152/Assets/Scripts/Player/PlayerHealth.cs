using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    GameObject playerSpawner;

    public GameObject deathSound;

    public GameUI ui;
    public PlayerAudioController playerAudio;

    public int health;
    public int maxHealth;

    public bool isRegenerating = false;
    private float timeBetweenHealthUpRegen = 5f;
    private float timer;

    void Start()
    {
        SendHealthData();
        maxHealth = 100;
        health = 100;
    }

    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (isRegenerating && timer <= 0)
        {
            timer = timeBetweenHealthUpRegen;
            HealthPotion(1);
        }
    }

    public void TakeDamage(int damage)
    {
        playerAudio.PlayerDamageSound(0f);

        health -= damage;
        SendHealthData();

        if (health <= 0)
        {
            //playerAudio.PlayerDeathSound(0f);
            Instantiate(deathSound);

            Die();
        }
    }

    public void HealthPotion(int healthRegained)
    {
        if (health >= maxHealth - healthRegained && health != maxHealth)        // Ensures that the health doesn't go over max 
        {
            health = maxHealth;
        }
        else
        {
            health += healthRegained;
        }
      
        SendHealthData();
    }

    public void RefillHealth()      // From upgrades
    {
        if (health >= maxHealth - 50 && health != maxHealth)        // Ensures that the health doesn't go over max 
        {
            health = maxHealth;
        }
        else
        {
            health += 50;
        }

        SendHealthData();
    }

    public void IncreaseMaxHealth()     // Accessed from upgrades
    {
        maxHealth += 25;
        SendHealthData();
    }

    void Die()
    {
        gameObject.SetActive(false);
        ui.playerDead = true;
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Pit")
        {
            TakeDamage(30);

            playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawn");
            this.transform.position = playerSpawner.transform.position;
        }
    }
}
