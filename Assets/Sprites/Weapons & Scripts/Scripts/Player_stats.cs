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
    public int[] defense_levelup;// defence at every level

    public int current_hp;
    public int current_attack;
    public int current_defense;

    private Player_health the_player_health;

    //add 10 damages for a sword
    public int attack_damage_from_item = 10;

    public int defense_from_item = 5;

    private int bonus_attack = 0;
    private int bonus_defense = 0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        the_player_health = FindObjectOfType<Player_health>();
        //set the stats for the level 1 player
        current_hp = hp_levelup[1];
        current_attack = attack_levelup[1] + bonus_attack;
        current_defense = attack_levelup[1] + bonus_defense;
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

        current_attack = attack_levelup[current_level] + bonus_attack;
        current_defense = defense_levelup[current_level] + bonus_defense;
    }

    public void Restart()
    {
        current_level = 1;
        current_hp = hp_levelup[1];
        current_attack = attack_levelup[1];
        current_defense = attack_levelup[1];
        current_exp = 0;
        
       

        the_player_health.player_max_health = current_hp;
        the_player_health.player_current_health = current_hp;
    }

    
    public void attack_increase_from_item(int number_of_sword)
    {
        bonus_attack = attack_damage_from_item * number_of_sword;
        current_attack = attack_levelup[current_level] + bonus_attack;
    }

    public void defense_increase_from_item(int number_of_shield)
    {
        bonus_defense = defense_from_item * number_of_shield;
        current_defense = defense_levelup[current_level] + bonus_defense;
    }


    public void restore_health(int health_to_restore)
    {
        current_hp += health_to_restore;
        // check if we reach maximum health 
        if (current_hp > hp_levelup[current_level])
            current_hp = hp_levelup[current_level];
    }

    public int maximum_hp()
    {
        return hp_levelup[current_level];
    }
}
