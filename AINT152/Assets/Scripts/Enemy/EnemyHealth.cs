using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using Pathfinding;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    public AIPath movementparent;

    private WaveController controller;
    public GameObject emitter;

    public GameObject healthDrop;

    public UnityEvent onTakeDamage;

    private float currentEnemyMaxSpeed;

    private void Start()
    {
        currentEnemyMaxSpeed = movementparent.maxSpeed;

        controller = GameObject.FindGameObjectWithTag("WaveController").GetComponent(typeof(WaveController)) as WaveController;
    }

    public void TakeDamage(int damage)
    {
        if (health < 1) return;

        health -= damage;
        onTakeDamage.Invoke();

        if (health <= 0)
        {
            GetComponent<AddScore>().DoSendScore();
            DropStuff();
            Destroy(transform.parent.gameObject);

            controller.ReduceEnemies();
        }       
    }

    public void SlowDown(float strength)
    {
        if(movementparent.maxSpeed == currentEnemyMaxSpeed)
        {
            movementparent.maxSpeed = currentEnemyMaxSpeed / strength;

            Invoke("SpeedUp", 0.2f);
        }       
    }

    public void SpeedUp()
    {
        movementparent.maxSpeed = currentEnemyMaxSpeed;
    }

    void DropStuff()        // Drop health based on probabilities
    {
        if(Random.Range(0, 100) <= 30)      // 50% chance to spawn anything
        {
            if(Random.Range(0, 100) <= 80)      // If anything is spawned, 80% chance that it's just one
            {
                Instantiate(healthDrop, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));               
            }
            else if(Random.Range(0, 100) <= 95)     // Between 80 and 95 anywehre from 1 to 3 can be spawned
            {
                for (int i = 0; i < Random.Range(1, 3); i++)
                {
                    Instantiate(healthDrop, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                }
            }
            else
            {
                for (int i = 0; i < Random.Range(1, 4); i++)        // From 95 to 100 is 1 to 4 health drops
                {
                    Instantiate(healthDrop, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                }
            }
        }        
    }
}
