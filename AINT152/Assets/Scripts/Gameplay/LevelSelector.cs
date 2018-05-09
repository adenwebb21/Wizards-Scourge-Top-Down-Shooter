using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

    Grid[] levels;
    Grid chosenLevel;

    private void Start()
    {
        SetLevel();
    }

    public void SetLevel()
    {
        levels = GetComponentsInChildren<Grid>(true);       // Get all levels available ...

        chosenLevel = levels[Random.Range(0, levels.Length)];       // ... and pick a random one

        foreach(Grid level in levels)       // Enable the correct one and disable all others
        {
            if(level == chosenLevel)
            {
                level.gameObject.SetActive(true); 
            }
            else
            {
                level.gameObject.SetActive(false);
            }
        }

        AstarPath.active.Scan();        // Rescan for pathfinding
    }
}
