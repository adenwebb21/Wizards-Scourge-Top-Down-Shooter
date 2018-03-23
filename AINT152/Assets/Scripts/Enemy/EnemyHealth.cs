using UnityEngine;
using System.Collections;
public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GetComponent<AddScore>().DoSendScore();

            Destroy(transform.parent.gameObject);
        }
    }
}
