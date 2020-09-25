using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] items;
    private Player_stats the_player_stats;
    private Player_health the_player_health;

    private int sword_index;
    private int shield_index;
    private int health_potion_index;
    private int mana_potion_index;
    private int berry_index;

    public float percent_health_to_restore;

    // Start is called before the first frame update
    void Start()
    {
        
        the_player_stats = FindObjectOfType<Player_stats>();
        the_player_health = FindObjectOfType<Player_health>();

        //start indexing everything 
        //set everything to zero

        for (int i = 0; i < items.Length; i++)
        {
            switch (items[i].item_name)
            {
                case "sword":
                    sword_index = i;
                    items[i].quantity = 0;
                    break;

                case "shield":
                    shield_index = i;
                    items[i].quantity = 0;

                    break;

                case "health_potion":
                    health_potion_index = i;
                    items[i].quantity = 0;

                    break;

                case "berry":
                    berry_index = i;
                    items[i].quantity = 0;

                    break;

                case "mana_potion":
                    mana_potion_index = i;
                    items[i].quantity = 0;

                    break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_item(Item item_to_add)
    {
        int item_index = return_item_index(item_to_add.item_name);
        items[item_index].quantity += item_to_add.quantity;

        update_stats();
    }

    // the player will press a button to use one health potion in order to restore some of his missing health
    public void use_health_potoin()
    {
        //check if we have any health potion to use 
        if (items[health_potion_index].quantity <= 0)
        {
            //play some sound indicating we don't have any health potion left
            return;
        }

        //health potion will restore % of player current maximum health
        //calculating the health to restore
        int health_to_restore = 0;
        health_to_restore = (int)(percent_health_to_restore/100 * the_player_stats.maximum_hp());

        the_player_health.restore_health(health_to_restore);
        items[health_potion_index].quantity -= 1;

    }

    public void update_stats()
    {
        int sword_number = items[sword_index].quantity;
        int shield_number = items[shield_index].quantity;

        the_player_stats.attack_increase_from_item(sword_number);
        the_player_stats.defense_increase_from_item(shield_number);

        
    }

    public int return_item_index(string item_name)
    {
        switch (item_name)
        {
            case "sword":
                return sword_index;
                

            case "shield":
                return shield_index;


            case "health_potion":
                return health_potion_index;


            case "berry":
                return berry_index;
                

            case "mana_potion":
                return mana_potion_index;
        }

        return -1;
    }
}
