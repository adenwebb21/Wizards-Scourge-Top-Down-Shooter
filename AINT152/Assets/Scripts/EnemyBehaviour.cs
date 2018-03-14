using UnityEngine;
using System.Collections;
public class EnemyBehaviour : MonoBehaviour
{
    public int health = 10;
    public int damage;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
