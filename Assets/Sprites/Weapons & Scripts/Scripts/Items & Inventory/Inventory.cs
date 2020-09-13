using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item current_item;
    public List<Item> items = new List<Item>();
    public int number_of_keys;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_item(Item item_to_add)
    {
        //Is the Item a key
        if (item_to_add.is_key)
        {
            number_of_keys++;
        }
        else 
        {
            if (!items.Contains(item_to_add))
            {
                items.Add(item_to_add);
            }
        }
    }
}
