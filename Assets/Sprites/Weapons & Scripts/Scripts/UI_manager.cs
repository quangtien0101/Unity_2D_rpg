using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    //refering to the UI
    public Slider health_bar;
    public Text hp_text_number;

    public Slider xp_bar;
    public Text xp_text_number;
    public Text level_number;
    //refering to the script that manage the player health
    private Player_health player_health;
    private Player_stats player_stats;

    private static bool UI_Exist;

    // Start is called before the first frame update
    void Start()
    {
        if (!UI_Exist)
        {
            UI_Exist = true;
            DontDestroyOnLoad(transform.gameObject);
            player_health = FindObjectOfType<Player_health>();
        }
        else
        {
            Destroy(gameObject);
        }

        player_stats = GetComponent<Player_stats>();
    }

    // Update is called once per frame
    void Update()
    {
        health_bar.maxValue = player_health.player_max_health;
        health_bar.value = player_health.player_current_health;

        hp_text_number.text = "" + player_health.player_current_health + "/" + player_health.player_max_health;

        xp_bar.maxValue = player_stats.exp_levelup[player_stats.current_level];
        xp_bar.value = player_stats.current_exp;
        xp_text_number.text = "" + xp_bar.value + "/" + xp_bar.maxValue;
        level_number.text = "Level " + player_stats.current_level;
    }
}
