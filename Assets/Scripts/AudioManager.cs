﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    bool isPlaying = true;
    

    void Start()
    {
        if (FindObjectsOfType<AudioManager>().Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public bool IsPlaying => isPlaying;
    public void PlayOrMute()
    {
        
        if (isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
        isPlaying = !isPlaying;
    }

    // Update is called once per frame

}
