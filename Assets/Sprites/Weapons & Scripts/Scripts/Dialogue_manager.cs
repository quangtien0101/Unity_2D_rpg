using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_manager : MonoBehaviour
{
    public GameObject dialouge_box;
    public Text dialouge_text;

    public bool dialouge_active;
    public string[] dialog_lines;

    public int current_line;

    private player_controller the_player;
    // Start is called before the first frame update
    void Start()
    {
        the_player = FindObjectOfType<player_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialouge_active && Input.GetKeyDown(KeyCode.Return))
        {
            
            current_line++ ;
        }
        if (current_line >= dialog_lines.Length)
        {
            dialouge_box.SetActive(false);
            dialouge_active = false;
            
            current_line = 0;
            the_player.can_move = true;
        }
        dialouge_text.text = dialog_lines[current_line];
    }

    public void show_box(string dialogue)
    {
        dialouge_active = true;
        dialouge_box.SetActive(true);
        dialouge_text.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialouge_active = true;
        dialouge_box.SetActive(true);
        the_player.can_move = false;
    }
}
