using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Chest : MonoBehaviour
{
    //what is in the chest
    
    public bool is_open = false;
   
    private Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // player enter the zone, and open the chest
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKey(KeyCode.Return))
            {
                if (!is_open) 
                {
                    is_open = true;
                    anim.SetBool("open_chest", true);
                }
             
            }
        }
    }
}
