using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    GameObject playerSpawner;

    public GameUI ui;

    public int health = 100;

    void Start()
    {
        SendHealthData();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        SendHealthData();

        if (health <= 0)
        {
            Die();
        }
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
            TakeDamage(health / 2);

            playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawn");
            this.transform.position = playerSpawner.transform.position;
        }
    }

    public void ResetPlayer()
    {

    }

}
