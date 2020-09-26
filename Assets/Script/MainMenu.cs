using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private player_controller the_player;

    // Start is called before the first frame update
    public void Start()
    {
        the_player = FindObjectOfType<player_controller>();

    }
    public void PlayGame () {
        SceneManager.LoadScene("1");
        the_player.start_point = "Main entrance";
    }

    public void QuitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }
}
