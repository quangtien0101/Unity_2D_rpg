using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_trigger : MonoBehaviour
{
    private Quest_manager the_QM;
    public int questNumber;

    public bool start_quest;
    public bool end_quest;

    // Start is called before the first frame update
    void Start()
    {
        the_QM = FindObjectOfType<Quest_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (!the_QM.quest_completed[questNumber])
            {
                if (start_quest && !the_QM.quests[questNumber].gameObject.activeSelf)
                {
                    the_QM.quests[questNumber].gameObject.SetActive(true);
                    the_QM.quests[questNumber].Start_quest();
                }

                if (end_quest && the_QM.quests[questNumber].gameObject.activeSelf)
                {
                    the_QM.quests[questNumber].End_quest();     
                }
            }
        }
    }
}
