using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    int currentWave = 0;
    public int enemiesRemaining;

    public LevelSelector levelSelector;
    public RandomSpawner randomSpawner;

    private void Start()
    {

    }

    private void Update()
    {
        if(enemiesRemaining == 0)
        {
            currentWave++;
            enemiesRemaining = currentWave + 4;

            levelSelector.SetLevel();

            randomSpawner.numberOfEnemyInWave = enemiesRemaining;
            randomSpawner.StartNewWave();
        }
    }

    public void ReduceEnemies()
    {
        enemiesRemaining--;
    }
}
