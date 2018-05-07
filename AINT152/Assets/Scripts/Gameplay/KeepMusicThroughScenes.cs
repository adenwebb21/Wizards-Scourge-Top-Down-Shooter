using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMusicThroughScenes : MonoBehaviour {

    private AudioSource audioMusic;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioMusic = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (audioMusic.isPlaying) return;
        audioMusic.Play();
    }

    public void StopMusic()
    {
        audioMusic.Stop();
    }
}
