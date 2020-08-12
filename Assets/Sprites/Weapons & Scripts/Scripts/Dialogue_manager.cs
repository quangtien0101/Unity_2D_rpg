using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_manager : MonoBehaviour
{
    public GameObject dialouge_box;
    public Text dialouge_text;

    public bool dialouge_active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialouge_active && Input.GetKeyDown(KeyCode.Return))
        {
            dialouge_box.SetActive(false);
            dialouge_active = false;
        }
    }

    public void show_box(string dialogue)
    {
        dialouge_active = true;
        dialouge_box.SetActive(true);
        dialouge_text.text = dialogue;
    }
}
