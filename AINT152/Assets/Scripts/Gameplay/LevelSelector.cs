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
        levels = GetComponentsInChildren<Grid>(true);

        chosenLevel = levels[Random.Range(0, levels.Length)];

        foreach(Grid level in levels)
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

        AstarPath.active.Scan();
    }
}
