using UnityEngine;
using System.Collections;
public class BulletHit2D : MonoBehaviour
{
    public int damage = 1;
    public string damageTag = "";
    public GameObject particles;

    private void Start()
    {
        particles = GameObject.Find("BoltHitParticle");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            other.SendMessage("TakeDamage", damage);
        }
        if(!other.CompareTag("EnemyRadius") && !other.CompareTag("Pit") && !other.CompareTag("Untagged"))
        {
            Destroy(gameObject);
            Instantiate(particles.GetComponent<ParticleEmitter>());
        }
       
    }
}
