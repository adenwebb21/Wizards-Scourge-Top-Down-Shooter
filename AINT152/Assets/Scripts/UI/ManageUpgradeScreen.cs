using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageUpgradeScreen : MonoBehaviour {

    private RectTransform[] childrenPanels;

    public void EnableUpgradeScreen()       // Enables the upgrade screen correctly
    {
        childrenPanels = GetComponentsInChildren<RectTransform>(true);

        foreach (RectTransform panel in childrenPanels)
        {
            if(panel.gameObject.tag != "OptionalUpgrade")       // This would enable all options for the single upgrade spot - leading to bugs
            {
                panel.gameObject.SetActive(true);
            }           
        }
    }

    public void DisableUpgradeScreen()      // Disable everything upgrade screen flavoured
    {
        childrenPanels = GetComponentsInChildren<RectTransform>(true);

        foreach (RectTransform panel in childrenPanels)
        {
            panel.gameObject.SetActive(false);
        }
    }
}
