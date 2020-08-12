using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_holder : MonoBehaviour
{
    public string dialogue;
    private Dialogue_manager d_man;

    public string[] dialogue_lines;

    // Start is called before the first frame update
    void Start()
    {
        d_man = FindObjectOfType<Dialogue_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                //d_man.show_box(dialogue);
                if (!d_man.dialouge_active)
                {
                    d_man.dialog_lines = dialogue_lines;
                    d_man.current_line = 0;  
                    d_man.ShowDialogue();
                }

                if (transform.parent.GetComponent<Villager_movement>() != null)
                {
                    transform.parent.GetComponent<Villager_movement>().can_move = false;
                }
            }    
        }
    }
}
