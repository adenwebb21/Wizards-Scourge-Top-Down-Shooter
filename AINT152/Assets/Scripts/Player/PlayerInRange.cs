using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour {

    public Collider2D enemyDetection;
    public GameObject enemy;

    private void Start()
    {
        Component enemyAttackScript = enemy.GetComponent<EnemyAttack>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == enemyDetection)
        {
            enemy.GetComponent<EnemyAttack>().playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other == enemyDetection)
        {
            enemy.GetComponent<EnemyAttack>().playerInRange = false;
        }
    }
}
