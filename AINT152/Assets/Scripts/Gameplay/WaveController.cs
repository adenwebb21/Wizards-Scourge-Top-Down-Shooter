using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public int currentWave = 0;
    public int enemiesRemaining;

    public LevelSelector levelSelector;
    public RandomSpawner randomSpawner;
    public GameUI uiManager;

    private GameObject playerSpawner;

    private GameObject player;

    private void Start()
    {

    }

    private void Update()
    {
        if(enemiesRemaining == 0 && currentWave!= 0)
        {
            uiManager.waveVictory = true;

            currentWave++;
            enemiesRemaining = currentWave + Random.Range(1, 5);
        }

        if(currentWave == 0)
        {
            currentWave++;
            enemiesRemaining = currentWave + Random.Range(1, 5);

            LoadNextLevel();
        }
    }

    public void ReduceEnemies()
    {
        enemiesRemaining--;
    }

    public void LoadNextLevel()
    {
        GameObject[] allShots = GameObject.FindGameObjectsWithTag("Bolt");
        GameObject[] allPickups = GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject obj in allShots)
        {
            Destroy(obj);
        }

        foreach (GameObject obj in allPickups)
        {
            Destroy(obj);
        }

        levelSelector.SetLevel();

        randomSpawner.numberOfEnemyInWave = enemiesRemaining;
        randomSpawner.StartNewWave();

        playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawn");
        player = GameObject.Find("Player");
        player.transform.position = playerSpawner.transform.position;
    }
}
