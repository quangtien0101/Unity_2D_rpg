using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDie : MonoBehaviour
{
    public void RestartGame () {
        SceneManager.LoadScene("Menu");
    }
}