using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    public int enemy_max_health;
    public int enemy_current_health;

    public int  exp_to_give;
    private Player_stats player_stats;

    public GameObject[] loot_drop;
    private Vector3 loot_position;


    public string enemy_quest_name;
    private Quest_manager the_QM;


    // Start is called before the first frame update
    void Start()
    {
        enemy_current_health = enemy_max_health;

        player_stats = FindObjectOfType<Player_stats>();

        the_QM = FindObjectOfType<Quest_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_current_health <= 0)
        {
            //give the name of the current enemy to the quest manager 
            the_QM.enemy_killed = enemy_quest_name;

            //gameObject.SetActive(false);
          

            //droping loot
            int max_loot = loot_drop.Length;

            loot_position = transform.position;
            for (int i = 0; i < max_loot; i++)
                Instantiate(loot_drop[i], loot_position, Quaternion.identity);
            
            player_stats.Add_exp(exp_to_give);

            Destroy(gameObject);

        }

    }

    public void Hurt_enemy(int damage_to)
    {
        enemy_current_health = enemy_current_health - damage_to;
    }

    public void Set_max_health()
    {
        enemy_current_health = enemy_max_health;
    }
}
