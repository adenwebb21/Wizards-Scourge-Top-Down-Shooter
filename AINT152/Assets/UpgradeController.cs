using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameUI UI;

    private int buttonSelected = 0;

    public void RefillHealth()
    {
        buttonSelected = 1;
    }

    public void IncreaseMaxHealth()
    {
        buttonSelected = 2;
    }

    public void ActivateSelection()
    {
        switch(buttonSelected)
        {
            case 1:
                playerHealth.RefillHealth();
                break;
            case 2:
                playerHealth.IncreaseMaxHealth();
                break;
            default:
                break;
        }

        buttonSelected = 0;
    }


	
}
