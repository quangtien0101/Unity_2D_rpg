using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float move_Speed;
    private float current_move_speed;
    public float diagonal_modifier;

    public SpriteRenderer player_sprite;
    private Animator anim;
    private Rigidbody2D player_rigid;

    public GameObject weapon;
    private SpriteRenderer weapon_sprite;

    private bool player_moving;
    public Vector2 last_move;

    private static bool playerExists;

    private bool attacking;
    public float attack_time;
    private float attack_time_counter;

    //handling the start position of the player in every sceen
    public string start_point;

    public bool can_move = true;

    private SFX_manager SFX_MAN;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player_sprite = GetComponent<SpriteRenderer>();
        player_rigid = GetComponent<Rigidbody2D>();
        SFX_MAN = FindObjectOfType<SFX_manager>();

        //for moving between levels
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x_axis_input = 0f;
        float y_axis_input = 0f;

        if (!can_move)
        {
            player_rigid.velocity = Vector2.zero;
            return;
        }

        if (!attacking)
        {
            x_axis_input = Input.GetAxisRaw("Horizontal");
            y_axis_input = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attack_time_counter = attack_time;
                attacking = true;
                player_rigid.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
                weapon.GetComponent<Hurt_enemy>().on = true;

                SFX_MAN.player_attack.Play();
            }

            if ((Mathf.Abs(x_axis_input) > 0.5f) && (Mathf.Abs(y_axis_input) > 0.5f))
                current_move_speed = move_Speed *diagonal_modifier;
            else
                current_move_speed = move_Speed;

        }

        // check if player is moving
        if (x_axis_input == 0 && y_axis_input == 0)
            player_moving = false;
        else
            player_moving = true;


        if (x_axis_input != 0)
        {
            last_move = new Vector2(x_axis_input, 0f);
            //y_axis_input = 0; // this line will prevent the player go diagonal
        }
        if (y_axis_input != 0)
        {
            last_move = new Vector2(0f,y_axis_input);
            //x_axis_input = 0; // this line will prevent the player go diagonal
        }

        float move_horizontal = x_axis_input * current_move_speed;// * Time.deltaTime;
        float move_vertical = y_axis_input * current_move_speed;// * Time.deltaTime; 

        //transform.Translate(new Vector3(move_horizontal, move_vertical, 0f));
        
        player_rigid.velocity = new Vector2(move_horizontal, move_vertical);


        if (attack_time_counter > 0)
        {
            attack_time_counter -= Time.deltaTime;
        }
        if (attack_time_counter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
            weapon.GetComponent<Hurt_enemy>().on = false;

        }

        anim.SetFloat("MoveX", x_axis_input);
        anim.SetFloat("MoveY", y_axis_input);
        anim.SetBool("PlayerMoving", player_moving);
        anim.SetFloat("LastMoveX", last_move.x);
        anim.SetFloat("LastMoveY", last_move.y);
    } 

}
 