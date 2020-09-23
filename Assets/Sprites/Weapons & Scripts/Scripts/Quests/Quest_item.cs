using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_item : MonoBehaviour
{
    public int quest_number;
    private Quest_manager the_QM;

    public string item_name;

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
            if (!the_QM.quest_completed[quest_number] && the_QM.quests[quest_number].gameObject.activeSelf)
            {
                the_QM.item_collected = item_name;
                gameObject.SetActive(false);
            }
        }
    }
}
