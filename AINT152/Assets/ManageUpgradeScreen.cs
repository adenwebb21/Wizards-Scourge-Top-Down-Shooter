using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageUpgradeScreen : MonoBehaviour {

    private RectTransform[] childrenPanels;

	public void EnableUpgradeScreen()
    {
        childrenPanels = GetComponentsInChildren<RectTransform>(true);

        foreach (RectTransform panel in childrenPanels)
        {
            panel.gameObject.SetActive(true);
        }
    }

    public void DisableUpgradeScreen()
    {
        childrenPanels = GetComponentsInChildren<RectTransform>(true);

        foreach (RectTransform panel in childrenPanels)
        {
            panel.gameObject.SetActive(false);
        }
    }
}
