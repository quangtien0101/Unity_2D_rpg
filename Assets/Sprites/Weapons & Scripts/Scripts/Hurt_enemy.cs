using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_enemy : MonoBehaviour
{
    public bool on;
    public int weapon_damage;
    private int current_damage;
    public GameObject damage_effect; // the particle effect to indicate that we hit our tartget

    public Transform impact_point; // where the particle effects will play
    public GameObject damage_number; //use to create the floating text indicate how much damage 

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (on)
        {
            if (other.gameObject.tag == "Enemy")
            {
                current_damage = weapon_damage + the_player_stats.current_attack;
                //Destroy(other.gameObject);
                other.gameObject.GetComponent<Enemy_health>().Hurt_enemy(current_damage);
                
                //create the particle hit effect
                Instantiate(damage_effect, impact_point.position, impact_point.rotation);

                //create a game object which controll the floating text indicate damages
                var clone = (GameObject) Instantiate(damage_number, impact_point.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<Floating_numbers>().damages = current_damage;
            }
        }
    }
}
