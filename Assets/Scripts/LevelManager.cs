using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int lastLevelSaved = PlayerPrefs.GetInt("LastLevelSaved");
        PlayerPrefs.SetInt($"Level{lastLevelSaved+1}Unlocked", 1);

    }

    // Update is called once per frame
}
