using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : MonoBehaviour
{
    public int current_level;
    public int current_exp;

    public int[] exp_levelup; //xp requires to leveling up 

    public int[] hp_levelup; //hp at every level
    public int[] attack_levelup;// attack damage at every level
    public int[] defence_levelup;// defence at every level

    public int current_hp;
    public int current_attack;
    public int current_defence;

    private Player_health the_player_health;

    // Start is called before the first frame update
    void Start()
    {
        the_player_health = FindObjectOfType<Player_health>();
        //set the stats for the level 1 player
        current_hp = hp_levelup[1];
        current_attack = attack_levelup[1];
        current_defence = attack_levelup[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (current_exp >= exp_levelup[current_level])
        {
            //current_level++;
            Level_up();
            current_exp = 0; //reset the experience upon leveling up
        }
    }

    public void Add_exp(int exp) 
    {
        current_exp += exp;
    }

    public void Level_up()
    {
        current_level++;
        
        //when leveling up, the player will receive additional health from leveling up
         
        current_hp = hp_levelup[current_level];
        the_player_health.player_max_health = current_hp;
        the_player_health.player_current_health += current_hp - hp_levelup[current_level-1];

        current_attack = attack_levelup[current_level];
        current_defence = defence_levelup[current_level];
    }
}
