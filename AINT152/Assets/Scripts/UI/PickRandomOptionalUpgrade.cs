using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickRandomOptionalUpgrade : MonoBehaviour
{
    public WaveController wvCont;
    private Button chosenButton;

    private Button[] upgrades;

    private void OnEnable()
    {
        upgrades = GetComponentsInChildren<Button>(true);

        switch (wvCont.currentWave - 1)
        {
            case 5:
                chosenButton = upgrades[0];
                break;
            case 10:
                chosenButton = upgrades[1];
                break;
            default:
                chosenButton = null;
                break;
        }

        chosenButton.gameObject.SetActive(true);

        // RANDOM UPGRADES ONLY APPEARING ONCE IS HARD - PRESET FOR NOW

        //while (chosenButton == null)
        //{
        //    chosenButton = controller.upgrades[Random.Range(0, controller.upgrades.Length)];
        //}

        //for (int i = 0; i < upgrades.Length - 1; i++)
        //{
        //    if (upgrades[i] == chosenButton)
        //    {
        //        chosenButton.gameObject.SetActive(true);
        //        //controller.upgrades[i] = null;
        //        chosenButton = null;
        //    }
        //    else
        //    {
        //        upgrades[i].gameObject.SetActive(false);
        //    }
        //}
    }

    private void OnDisable()
    {
        foreach(Button element in upgrades)
        {
            element.gameObject.SetActive(false);
        }
    }
}
