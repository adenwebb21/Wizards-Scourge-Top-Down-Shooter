using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickRandomOptionalUpgrade : MonoBehaviour
{

    private Button[] buttonOptions;
    private Button chosenButton;

    private void OnEnable()
    {
        buttonOptions = GetComponentsInChildren<Button>(true);
        chosenButton = buttonOptions[Random.Range(0, buttonOptions.Length)];

        foreach (Button upgrade in buttonOptions)       // Enable the correct one and disable all others
        {
            if (upgrade == chosenButton)
            {
                upgrade.gameObject.SetActive(true);
            }
            else
            {
                upgrade.gameObject.SetActive(false);
            }
        }
    }
}
