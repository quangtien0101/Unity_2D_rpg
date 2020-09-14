using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_gold : MonoBehaviour
{
    public int value;
    public Money_management the_mm;

    // Start is called before the first frame update
    void Start()
    {
        the_mm = FindObjectOfType<Money_management>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            the_mm.Add_gold(value);
            Destroy(gameObject);
        }
    }
}
