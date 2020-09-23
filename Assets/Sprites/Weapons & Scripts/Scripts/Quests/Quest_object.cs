using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_object : MonoBehaviour
{

    public int quest_number;
    public Quest_manager the_qm;

    public string start_text;
    public string end_text;

    public bool is_quest_item;
    public string target_item;

    public bool is_enemy_quest;
    public string target_enemy;
    public int enemies_to_kill;
    private int enemy_kill_count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_quest_item)
        {
            if (the_qm.item_collected == target_item)
            {
                the_qm.item_collected = null;
                End_quest();
            }
        }

        if (is_enemy_quest)
        {
            if (the_qm.enemy_killed == target_enemy)
            {
                the_qm.enemy_killed = null;
                enemy_kill_count ++;
            }

            if (enemy_kill_count >= enemies_to_kill)
            {
                End_quest();
            }
        }
    }

    public void Start_quest()
    {
        the_qm.Show_quest_text(start_text);
    }

    public void End_quest()
    {
        //display the finish quest diaglouge
        the_qm.Show_quest_text(end_text);


        //mark the quest as completed once we finish it
        the_qm.quest_completed[quest_number] = true;
        gameObject.SetActive(false);

    }
}
