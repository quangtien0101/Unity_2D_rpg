using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private player_controller the_player;
    public GameObject pauseMenu;
    public bool isPause;
    public static bool pauseExist;
    // Start is called before the first frame update
    public void Start()
    {
      isPause = false;
      pauseMenu.SetActive(isPause);
      if (!pauseExist)
      {
        pauseExist = true;
        DontDestroyOnLoad(transform.gameObject);
      }
      else
      {
        Destroy(gameObject);
      }
    }

    void Update()
    {
      Scene scene = SceneManager.GetActiveScene();
      if (Input.GetKeyDown(KeyCode.P) && (scene.name != "Menu" || scene.name != "You Die"))
      {
        if (isPause) {
          ResumeGame();
        } else {
          PauseGame();
        }
      }
    }
    public void ResumeGame () {
      isPause = false;
      pauseMenu.SetActive(isPause);
      Time.timeScale = 1f;
      the_player.can_move = true;
    }

    public void PauseGame () {
      isPause = true;
      pauseMenu.SetActive(isPause);
      Time.timeScale = 0f;
      the_player.can_move = false;
    }

    public void SaveGame () {
        ResumeGame();
    }

    public void QuitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnToMenu () {
      ResumeGame();
      SceneManager.LoadScene("Menu");
    }
}
