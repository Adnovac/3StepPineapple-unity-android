using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTile : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI levelName;
    TextMeshProUGUI stepsCount;
    Button button;
    Image image;
    int levelNumber;
    void Start()
    {
        levelName = transform.GetComponentsInChildren<TextMeshProUGUI>()[0];
        stepsCount = transform.GetComponentsInChildren<TextMeshProUGUI>()[1];
        button = transform.GetComponentInChildren<Button>();
        image = transform.GetComponentInChildren<Image>();
        levelNumber = Int32.Parse(levelName.text);

        if (PlayerPrefs.GetInt($"Level{levelNumber}Unlocked") != 1 || !Application.CanStreamedLevelBeLoaded($"Level{levelNumber}"))
        {
            button.interactable = false;
            image.color = new Color(0x93, 0x8C, 0x8C);
        }
        else
        {
            int steps = PlayerPrefs.GetInt($"Level{levelNumber}Steps");
            if (steps>0)
                stepsCount.text = $"Steps: {PlayerPrefs.GetInt($"Level{levelNumber}Steps")}";
        }
    }

    // Update is called once per frame
    public void OpenLevel()
    {
        SceneManager.LoadScene($"Level{levelNumber}");
    }
}
