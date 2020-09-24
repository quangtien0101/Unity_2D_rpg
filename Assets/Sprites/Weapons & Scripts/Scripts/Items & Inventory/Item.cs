using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{


    public string item_name;
    public string item_description;
    public bool is_key;
    public int quantity;

    private Inventory the_inventory;

    // Start is called before the first frame update
    void Start()
    {
        the_inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //item will be remove from the ground if the player hit the item
    void OnTriggerStay2D(Collider2D other)
    {
        // we will add item to the player inventory
        if (other.gameObject.name == "Player")
        {
            the_inventory.Add_item(this);

            Destroy(this.gameObject);
        }
    }
}
