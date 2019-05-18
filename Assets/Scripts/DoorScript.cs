using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorScript : MonoBehaviour
{

    public Sprite opened1;
    public Sprite opened2;
    public Sprite closed1;
    public Sprite closed2;
    public RuleTile wall;
    Tilemap tileMap;
    public bool isOpened;
    Counter counter;
    AudioSource audioSource;
    Sprite doorOpened;
    Sprite doorClosed;
    
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {

        tileMap = GameObject.FindGameObjectWithTag("LevelTileMap").GetComponent<Tilemap>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        counter = FindObjectOfType<Counter>();
        Vector3 upPosition = transform.position + Vector3.up;
        Vector3 downPosition = transform.position + Vector3.down;
        Vector3Int cell = tileMap.WorldToCell(upPosition);
        RuleTile tile = tileMap.GetTile<RuleTile>(cell);
        if(tile==wall)
        {
            cell = tileMap.WorldToCell(downPosition);
            tile = tileMap.GetTile<RuleTile>(cell);
            if (tile==wall)
            {
                doorOpened = opened1;
                doorClosed = closed1;
            }

        }
        else
        {
            doorOpened = opened2;
            doorClosed = closed2;
        }
        if (isOpened)
            spriteRenderer.sprite = doorOpened;
        else
            spriteRenderer.sprite = doorClosed;

        counter.ThirdStepEvent += OnThirdStep;
    }

    // Update is called once per frame

    void OnThirdStep()
    {
        if (isOpened)
        {
            spriteRenderer.sprite = doorClosed;
        }
        else
        {
            spriteRenderer.sprite = doorOpened;
        }
        isOpened = !isOpened;
        audioSource.Play();
    }
}
