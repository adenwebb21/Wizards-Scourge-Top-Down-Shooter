using UnityEngine;
using System.Collections;
public class EnemyBehaviour : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
