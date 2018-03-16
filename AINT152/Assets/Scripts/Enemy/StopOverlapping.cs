using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StopOverlapping : MonoBehaviour {

    private AIDestinationSetter parentdestination;
    private Vector3 randomcoord;
    private Random r;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyRadius"))
        { 
            aipathparent.target = ;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRadius"))
        {
            aipathparent.maxSpeed = 2;
        }
    }
}
