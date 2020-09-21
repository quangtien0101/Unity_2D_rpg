using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_manager: MonoBehaviour
{
    public Quest_object[] quests;
    public bool[] quest_completed;

    public Dialogue_manager the_DM;

    public string item_collected;

    

    // Start is called before the first frame update
    void Start()
    {
        quest_completed = new bool[quests.Length];     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show_quest_text(string quest_text)
    {
        the_DM.dialog_lines = new string[1];
        the_DM.dialog_lines[0] = quest_text;

        the_DM.current_line = 0;
        the_DM.ShowDialogue();
    }
}
