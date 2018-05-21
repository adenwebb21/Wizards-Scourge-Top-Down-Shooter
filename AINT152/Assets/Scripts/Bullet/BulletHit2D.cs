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
        if (other.CompareTag(damageTag))        // These if statements are to determine different strengths and effects for different shot types
        {
            other.SendMessage("TakeDamage", damage);

            if(this.gameObject.name == "Bolt(Clone)")       // Effects for regular bolt       
            {
                other.SendMessage("GetStunDuration", 0.2f);
                other.SendMessage("GetStunStrength", 4);
            }
            else if(this.gameObject.name == "ShotgunBolt(Clone)")       // Shotgun stuns for longer
            {
                other.SendMessage("GetStunDuration", 0.4f);
                other.SendMessage("GetStunStrength", 4);
            }

            other.SendMessage("SlowDown");           
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
