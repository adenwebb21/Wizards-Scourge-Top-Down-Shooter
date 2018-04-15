using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public Text deathtext;

    public void Fade()
    {
        for (float i = 0; i <= 5; i += Time.deltaTime)
        {
            deathtext.color = new Color(231, 14, 14, i);
        }
    }
}
