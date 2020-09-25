using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_health : MonoBehaviour
{
    public int player_max_health;
    public int player_current_health;

    //to indicating the player get damaged
    private bool flash_active;
    public float flash_length;
    private float flash_counter;
    private SpriteRenderer player_sprite;

    private SFX_manager SFX_MAN;
    private Music_manager Music_man;
    public bool is_dead = false;

    // Start is called before the first frame update
    void Start()
    {
        player_current_health = player_max_health;

        player_sprite = GetComponent<SpriteRenderer>();
        SFX_MAN = FindObjectOfType<SFX_manager>();
        Music_man = FindObjectOfType<Music_manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player_current_health <= 0 && is_dead == false) 
        {
            Music_man.music_can_play = false;

            SFX_MAN.player_dead.Play();
            //gameObject.SetActive(false);
            is_dead = true;

            SceneManager.LoadScene("You Die");

        }

        if (flash_active)
        {
            //making the player goes invisible
            if(flash_counter > flash_length * .66f)
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, 0f);

            else if (flash_counter > flash_length * .33f)
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, 1f);

            else if (flash_counter > 0f)
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, 0f);

            else             
            {
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, 1f);
                flash_active = false;
            }

            flash_counter -= Time.deltaTime;
        }
    }

    public void Hurt_player(int damage_to)
    {
        int remain_health = player_current_health - damage_to;

        if (remain_health >= 0) 
        {
            player_current_health = remain_health;
        }
        else
            player_current_health = 0;

        flash_active = true;
        flash_counter = flash_length;

        SFX_MAN.player_hurt.Play();
    }

    public void Set_max_health()
    {
        player_current_health = player_max_health;
    }

    public void Restart()
    {
        player_current_health = 1;
        Music_man.music_can_play = true;
        is_dead = false;
        gameObject.SetActive(true);
    }

    public void restore_health(int health_to_restore)
    {
        player_current_health += health_to_restore;
        if (player_current_health > player_max_health)
            player_current_health = player_max_health;
    }
}
