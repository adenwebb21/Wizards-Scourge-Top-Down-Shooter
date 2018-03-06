using UnityEngine;
using System.Collections;
public class ZombieBehaviour : MonoBehaviour
{
    public int health = 10;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}