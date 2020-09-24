using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bag_manager : MonoBehaviour
{
    public GameObject bag_box;
    public Text sword_count;
    public Text shield_count;
    public Text health_potion_count;
    public Text berry_count;
    public Text mana_potion_count;


    private Inventory the_inventory;

    public bool bag_active;

    private player_controller the_player;
    // Start is called before the first frame update
    void Start()
    {
        the_inventory = FindObjectOfType<Inventory>();
        the_player = FindObjectOfType<player_controller>();
        bag_active = false;
        bag_box.SetActive(bag_active);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void toggle_bag()
    {
        bag_active = !bag_active;
        if (bag_active)
        {
            update_number();
        }
        bag_box.SetActive(bag_active);

    }

    public void update_number()
    {
        for (int i = 0; i < the_inventory.items.Length; i++)
        {
            switch (the_inventory.items[i].item_name)
            {
                case "sword":
                    sword_count.text = "X" + the_inventory.items[i].quantity.ToString();
                    break;

                case "shield":
                    shield_count.text = "X" + the_inventory.items[i].quantity.ToString();
                    break;
                
                case "health_potion":
                    health_potion_count.text = "X" + the_inventory.items[i].quantity.ToString();
                    break;

                case "berry":
                    berry_count.text = "X" + the_inventory.items[i].quantity.ToString();
                    break;

                case "mana_potion":
                    mana_potion_count.text = "X" + the_inventory.items[i].quantity.ToString();
                    break;
            }

        }
    }

 
}
