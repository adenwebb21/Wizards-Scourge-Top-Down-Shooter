using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

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

    public void ResetPlayer()
    {

    }

}
