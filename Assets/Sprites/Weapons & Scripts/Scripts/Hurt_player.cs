using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_player : MonoBehaviour
{
    public int damage_to;
    private int current_damage;

    public GameObject damage_number;

    private Player_stats the_player_stats;



    // Start is called before the first frame update
    void Start()
    {
        the_player_stats = FindObjectOfType<Player_stats>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {

            current_damage = damage_to - the_player_stats.current_defense;
            if (current_damage <= 0)
                current_damage = 1;

            other.gameObject.GetComponent<Player_health>().Hurt_player(current_damage);
            var clone = (GameObject)Instantiate(damage_number, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<Floating_numbers>().damages = current_damage;

        }
       
    }
    
}
