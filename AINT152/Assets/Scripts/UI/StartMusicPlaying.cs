using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusicPlaying : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<KeepMusicThroughScenes>().PlayMusic();       // To be placed on any scripts I want the music playing on
    }

}
