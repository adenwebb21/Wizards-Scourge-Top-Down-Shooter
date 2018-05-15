using UnityEngine;
using System.Collections;
public class BulletHit2D : MonoBehaviour
{
    public int damage = 1;
    public string damageTag = "";

    public GameObject shotPos;
    public GameObject emitter;

    private Transform newPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            other.SendMessage("TakeDamage", damage);
        }

        if (other.CompareTag(damageTag))
        {
            Destroy(gameObject);
        }

        if (!other.CompareTag("EnemyRadius") && !other.CompareTag("Pit") && !other.CompareTag("Pickup") && !other.CompareTag("Untagged") && !other.CompareTag("Bolt") && !other.CompareTag("Player"))
        {
            CreateEffect();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }  
    }

    void CreateEffect()
    {
        newPos = shotPos.transform;
        Instantiate(emitter, newPos);
    }
}
