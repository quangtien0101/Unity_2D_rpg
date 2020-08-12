using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_controller: MonoBehaviour
{
    public float move_speed;

    private Rigidbody2D slime_rigid_body;

    private bool moving;
    public float time_between_move;
    private float time_between_move_counter;

    public float time_to_move;
    private float time_to_move_counter;

    public float wait_to_reload;
    private bool reloading;

    private Vector3 move_direction;

    private GameObject the_player;

    // Start is called before the first frame update
    void Start()
    {
        slime_rigid_body = GetComponent<Rigidbody2D>();

        //time_between_move_counter = time_between_move;
        //time_to_move_counter = time_to_move;

        //controll the randomness of when the slime will move
        // this help all the slimes not to move at the same time
        time_between_move_counter = Random.Range(time_between_move * 0.75f, time_between_move * 1.25f);
        time_to_move_counter = Random.Range(time_to_move * 0.75f, time_to_move * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {

        //controlling how the slime moves
        if (moving)
        {
            time_to_move_counter -= Time.deltaTime;
            slime_rigid_body.velocity = move_direction;

            if (time_to_move_counter < 0f)
            {
                moving = false;
                //time_between_move_counter = time_between_move;
                time_between_move_counter = Random.Range(time_between_move * 0.75f, time_between_move * 1.25f);

            }
        }
        else
        {
            time_between_move_counter -= Time.deltaTime;
            slime_rigid_body.velocity = Vector2.zero;

            if (time_between_move_counter < 0f)
            {
                moving = true;
                //time_to_move_counter = time_to_move;
                time_to_move_counter = Random.Range(time_to_move * 0.75f, time_to_move * 1.25f);

                move_direction = new Vector3(Random.Range(-1f, 1f) * move_speed, Random.Range(-1f, 1f) * move_speed, 0f);

            }
        }

        if (reloading)
        {
            wait_to_reload -= Time.deltaTime;
            if (wait_to_reload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                the_player.SetActive(true);

            }
        }
    }

    // when the player hits the slime --> deactivate the player
/*    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.name == "Player")
        {
            other.gameObject.SetActive(false);
            reloading = true;

            the_player = other.gameObject;
        }
        

    }
*/
}
