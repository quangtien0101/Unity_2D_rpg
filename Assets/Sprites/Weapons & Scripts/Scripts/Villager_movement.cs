using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float move_speed;
    private Rigidbody2D my_rigid_body;

    public bool is_walking;
    public float walk_time;
    public float wait_time;

    private float walk_counter;
    private float wait_counter;

    private int walk_direction;

    public Collider2D walk_zone;
    private Vector2 min_walk_point;
    private Vector2 max_walk_point;

    private bool has_walk_zone = false;
    
    void Start()
    {
        my_rigid_body = GetComponent<Rigidbody2D>();
        wait_counter = wait_time; 
        walk_counter = walk_time;
        choose_Direction();

        if (walk_zone != null)
        {
            min_walk_point = walk_zone.bounds.min;
            max_walk_point = walk_zone.bounds.max;
            has_walk_zone = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (is_walking)
        {
            walk_counter -= Time.deltaTime;
            
            switch (walk_direction)
            {
                case 0:
                    my_rigid_body.velocity = new Vector2(0, move_speed);
                    if (has_walk_zone && transform.position.y > max_walk_point.y)
                    {
                        is_walking = false;
                        wait_counter = wait_time;
                    }
                    break;
                case 1:
                    my_rigid_body.velocity = new Vector2(move_speed,0);
                    if (has_walk_zone && transform.position.x > max_walk_point.x)
                    {
                        is_walking = false;
                        wait_counter = wait_time;
                    }
                    break;
                case 2:
                    my_rigid_body.velocity = new Vector2(0,-move_speed);
                    if (has_walk_zone && transform.position.y < min_walk_point.y)
                    {
                        is_walking = false;
                        wait_counter = wait_time;
                    }
                    break;
                case 3:
                    my_rigid_body.velocity = new Vector2(-move_speed,0);
                    if (has_walk_zone && transform.position.x < min_walk_point.x)
                    {
                        is_walking = false;
                        wait_counter = wait_time;
                    }
                    break;
            }

            if (walk_counter < 0)
            {
                is_walking = false;
                wait_counter = wait_time;
            }

        }
        else
        {
            wait_counter -= Time.deltaTime;
            my_rigid_body.velocity = Vector2.zero;

            if (wait_counter < 0)
            {
                choose_Direction();
            }
        }
    }
    public void choose_Direction()
    {
        walk_direction = Random.Range(0, 4);
        is_walking = true;
        walk_counter = walk_time;

    }
}
