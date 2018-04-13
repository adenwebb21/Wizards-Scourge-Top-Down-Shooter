using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StopOverlapping : MonoBehaviour {

    public AIPath pathStats;

    private float checkRate = 1f;
    private float nextCheck;

    private void Start()
    {
        nextCheck = Time.time;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "EnemyRadius")
    //    {
    //        if (Random.Range(0, 1) == 0)
    //        {
    //            SlowDown();
    //        }
    //        else
    //        {
    //            collision.gameObject.GetComponent<StopOverlapping>().SlowDown();
    //        }
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "EnemyRadius" && Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;

            if (Random.Range(0, 1) == 0)
            {
                SlowDown();
                collision.gameObject.GetComponent<StopOverlapping>().SpeedUp();
            }
            else
            {
                SpeedUp();
                collision.gameObject.GetComponent<StopOverlapping>().SlowDown();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpeedUp();
    }

    void SlowDown()
    {
        while(pathStats.maxSpeed > 2)
        {
            pathStats.maxSpeed -= 0.01f;
        }      
    }

    void SpeedUp()
    {
        while (pathStats.maxSpeed < 4)
        {
            pathStats.maxSpeed += 0.01f;
        }     
    }
}
