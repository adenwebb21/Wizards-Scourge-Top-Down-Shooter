using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

    public GameObject enemy;
    public float Timer = 2;

    public int numberOfEnemyInWave;

    int enemyCount;

    GameObject[] spawners;
    GameObject chosenSpawner;

    GameObject enemyClone;

    private void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("SpawningLocation");
    }

    public void StartNewWave()
    {
        enemyCount = 0;
        spawners = GameObject.FindGameObjectsWithTag("SpawningLocation");
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        chosenSpawner = spawners[Random.Range(0, spawners.Length)];

        if(enemyCount < numberOfEnemyInWave)
        {
            CreateEnemy();
        }   
    }

    private void CreateEnemy()
    {
        if (Timer <= 0f)
        {
            enemyClone = Instantiate(enemy, chosenSpawner.transform.position, transform.rotation) as GameObject;
            enemyCount++;
            Timer = 2f;
        }
    }
}
