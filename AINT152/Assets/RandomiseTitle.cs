using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomiseTitle : MonoBehaviour
{
    private Text title;

    void Start()
    {
        title = gameObject.GetComponent<Text>();

        if(Random.Range(0, 100) == 100)
        {
            title.text = "~ Goblin Party!! ~";
        }
    }

}
