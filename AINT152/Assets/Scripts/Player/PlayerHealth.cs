using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    GameObject playerSpawner;

    public GameUI ui;
    public PlayerAudioController playerAudio;

    public int health;
    public int maxHealth;

    void Start()
    {
        SendHealthData();
        maxHealth = 100;
        health = 100;
    }

    public void TakeDamage(int damage)
    {
        playerAudio.PlayerDamageSound(0f);

        health -= damage;
        SendHealthData();

        if (health <= 0)
        {
            Die();
        }
    }

    public void HealthPotion(int healthRegained)
    {
        if (health >= maxHealth - 10 && health != maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healthRegained;
        }
      
        SendHealthData();
    }

    public void RefillHealth()
    {
        health = maxHealth;
        SendHealthData();
    }

    public void IncreaseMaxHealth()
    {
        maxHealth += 50;
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

    public void ResetPlayer()
    {

    }

}
