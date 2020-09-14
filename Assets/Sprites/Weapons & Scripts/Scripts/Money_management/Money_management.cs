using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Money_management : MonoBehaviour
{
    public Text gold_text;

    public int current_gold;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Current_gold"))
        {
            current_gold = PlayerPrefs.GetInt("Current_gold");

        }
        else 
        {
            current_gold = 0;
            PlayerPrefs.SetInt("Current_gold", 0);
        }
        gold_text.text = "Gold: " + current_gold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add_gold(int gold_to_add)
    {
        current_gold += gold_to_add;
        PlayerPrefs.SetInt("Current_gold", current_gold);
        gold_text.text = "Gold: " + current_gold;

    }
}
