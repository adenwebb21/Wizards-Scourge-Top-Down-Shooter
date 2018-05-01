using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameUI UI;

    public void RefillHealth()
    {
        playerHealth.RefillHealth();
    }
	
}
