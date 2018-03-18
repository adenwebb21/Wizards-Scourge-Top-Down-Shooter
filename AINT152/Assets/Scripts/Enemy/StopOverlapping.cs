using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StopOverlapping : MonoBehaviour {

    private AIDestinationSetter targetScript;
    private Transform currentTarget;

    private bool overlapping;

    private void Start()
    {
        targetScript = GetComponentInParent<AIDestinationSetter>();
        currentTarget = targetScript.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //currentTarget.position.x = currentTarget.position.x + 10;

        if(collision.CompareTag("EnemyRadius"))
        {
            overlapping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRadius"))
        {
            overlapping = false;
        }
    }

    private void Update()
    {
        
    }
}
