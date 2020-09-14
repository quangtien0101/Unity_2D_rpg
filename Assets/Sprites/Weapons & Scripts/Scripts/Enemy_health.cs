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

    // Start is called before the first frame update
    void Start()
    {
        enemy_current_health = enemy_max_health;

        player_stats = FindObjectOfType<Player_stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_current_health <= 0)
        {
            //gameObject.SetActive(false);
          
            Destroy(gameObject);

            //droping loot
            int max_loot = loot_drop.Length;
            for (int i = 0; i < max_loot; i++) 
            {
                loot_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                if (i % 2 == 0)
                {
                    loot_position.x += i/3;
                }
                if (i % 2 != 0)
                    loot_position.y += i/3;
                Instantiate(loot_drop[i], loot_position, Quaternion.identity);
            }
            
            player_stats.Add_exp(exp_to_give);
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
