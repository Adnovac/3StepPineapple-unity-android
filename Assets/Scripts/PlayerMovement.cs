using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Tilemap tilemap;
    public RuleTile wall;
    public Tile flag;
    List<DoorScript> doors = new List<DoorScript>();
    Vector3 lastPosition;
    AudioSource audioSource;
    Counter stepCounter;
    public AudioClip goal;

    void Start()
    {
        stepCounter  = FindObjectOfType<Counter>();
        doors = FindObjectsOfType<DoorScript>().ToList();
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    public void Move(Vector3Int vector)
    {
        if (vector + transform.position == lastPosition)
        {
            return;
        }
        Vector3Int cell = tilemap.WorldToCell(vector + transform.position);
        RuleTile ruleTile = tilemap.GetTile<RuleTile>(cell);
        Tile tile = tilemap.GetTile<Tile>(cell);
        if (ruleTile == wall)
        {
            return;
        }
        else if (tile == flag)
        {
            SaveStepsTaken();
            audioSource.clip = goal;
            audioSource.Play();
            StartCoroutine(Waiter(1));
          
        }
        foreach (DoorScript door in doors)
        {
            if (vector + transform.position == door.transform.position)
            {

                if (door.isOpened == true)
                {
                    break;
                }
                else
                {
                    return;
                }
            }
        }
        audioSource.Play();
        lastPosition = transform.position;
        transform.position = transform.position + vector;
        stepCounter.Step();
    }

    IEnumerator Waiter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene("LevelSelector");

    }

    void SaveStepsTaken()
    {
        string levelName = SceneManager.GetActiveScene().name;
        int stepsPrevious = PlayerPrefs.GetInt($"{levelName}Steps");
        if (stepCounter.Steps < stepsPrevious || stepsPrevious == 0)
            PlayerPrefs.SetInt($"{levelName}Steps", stepCounter.Steps);
        int levelNumber = System.Int32.Parse(levelName.Substring(levelName.LastIndexOf('l') + 1));
        PlayerPrefs.SetInt("LastLevelSaved", levelNumber);
    }
}

