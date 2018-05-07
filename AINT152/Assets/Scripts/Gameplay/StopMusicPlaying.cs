using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicPlaying : MonoBehaviour {

    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<KeepMusicThroughScenes>().StopMusic();
    }
}
