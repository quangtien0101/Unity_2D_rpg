using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] items;
    

    // Start is called before the first frame update
    void Start()
    {
        //set everything to zero
        for (int i = 0; i < items.Length; i++)
        {
                items[i].quantity = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_item(Item item_to_add)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item_name == item_to_add.item_name)
            {
                items[i].quantity += item_to_add.quantity;
                break;
            }
        }


    }

    // the player will press a button to use one health potion in order to restore some of his missing health
    public void use_health_potoin()
    { 
    }
}
