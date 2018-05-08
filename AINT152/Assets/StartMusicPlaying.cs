using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusicPlaying : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<KeepMusicThroughScenes>().PlayMusic();
    }

}
