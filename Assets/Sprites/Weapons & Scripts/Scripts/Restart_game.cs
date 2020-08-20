using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_game : MonoBehaviour
{
    private Player_health player_health;
    private Player_stats player_stats;

    // Start is called before the first frame update
    void Start()
    {
        player_health = FindObjectOfType<Player_health>();
        player_stats = FindObjectOfType<Player_stats>();

        player_health.Restart();
        player_stats.Restart();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
