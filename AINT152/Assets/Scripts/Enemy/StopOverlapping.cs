using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StopOverlapping : MonoBehaviour {

    AIPath pathStats;
    public CircleCollider2D radiusCollider;

    private void Start()
    {
        pathStats = GetComponentInParent<AIPath>();
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "EnemyRadius")
        {
            if (Random.Range(0, 1) == 0)
            {
                SlowDown();
            }
            else
            {
                collision.gameObject.GetComponent<StopOverlapping>().SlowDown();
            }
        }
        
    }

    void SlowDown()
    {
        if(pathStats.maxSpeed > 0)
        {
            pathStats.maxSpeed -= 0.2f;
        }      
    }

    void SpeedUp()
    {
        if (pathStats.maxSpeed < 4)
        {
            pathStats.maxSpeed += 0.2f;
        }     
    }
}
