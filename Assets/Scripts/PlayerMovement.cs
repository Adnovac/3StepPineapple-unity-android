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
    public GameObject stepCounterObject;
    List<DoorScript> doors = new List<DoorScript>();
    Vector3 lastPosition;
    AudioSource audioSource;
    Counter stepCounter;
    public AudioClip goal;

    void Start()
    {
        stepCounter = (Counter)stepCounterObject.GetComponent(typeof(Counter));
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
            audioSource.clip = goal;
            audioSource.Play();
            try
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            catch
            {
                SceneManager.LoadScene(0);
            }
            transform.position = transform.position + vector;
            return;
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
}

