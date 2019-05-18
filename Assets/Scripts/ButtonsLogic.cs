using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement player;
    public string direction;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void MoveAnanas()
    {
        switch (direction)
        {
            case "up":
                player.Move(Vector3Int.up);
                break;
            case "down":
                player.Move(Vector3Int.down);
                break;
            case "left":
                player.Move(Vector3Int.left);
                break;
            case "right":
                player.Move(Vector3Int.right);
                break;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
