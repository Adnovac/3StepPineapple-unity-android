using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    Toggle toggleBar;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {

        toggleBar = gameObject.GetComponent<Toggle>();
        audioManager = FindObjectOfType<AudioManager>();
        toggleBar.isOn = audioManager.IsPlaying;
    }
    public void PlayOrMute()
    {
        audioManager.PlayOrMute();
        toggleBar.isOn = audioManager.IsPlaying;
    }
}
