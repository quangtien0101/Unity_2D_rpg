using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_new_scene : MonoBehaviour
{
    public string levelToLoad;
    public string exit_point;

    private player_controller the_player;

    // Start is called before the first frame update
    void Start()
    {
        the_player = FindObjectOfType<player_controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
            the_player.start_point = exit_point;
             
        }
    }
}
