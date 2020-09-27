using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class Enemy_AI : MonoBehaviour
{
    private Transform target;
    public float speed = 20f;
    public float next_way_point_distance = 3f;

    public float sprite_default_x = 1;

    Path path;
    int current_waypoint_distance = 0;
    bool reached_end_of_path;

    Seeker seeker;
    Rigidbody2D enemy_RB;

    public Transform enemy_transform;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        enemy_RB = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;

        InvokeRepeating("Update_path", 0f, .4f); // update the path every 0.5s
    }

    void Update_path()
    {
        if(seeker.IsDone())
            seeker.StartPath(enemy_RB.position, target.position, On_path_complete);

    }

    private void On_path_complete(Path p)
    {
        if (!p.error)
        {
            path = p;
            current_waypoint_distance = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (current_waypoint_distance >= path.vectorPath.Count)
        {
            reached_end_of_path = true;
            return;
        }

        else 
        {
            reached_end_of_path = false;
        }

        Vector2 direction = ((Vector2) path.vectorPath[current_waypoint_distance] - enemy_RB.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        enemy_RB.AddForce(force);

        float distance = Vector2.Distance(enemy_RB.position, path.vectorPath[current_waypoint_distance]);

        if (distance < next_way_point_distance)
        {
            current_waypoint_distance++;
        }

        if (force.x >= 0.01f)
        {
            enemy_transform.localScale = new Vector3(sprite_default_x *-1f, 1f, 1f);

        }
        else if (force.x <= -0.01f)
        {
            enemy_transform.localScale = new Vector3(sprite_default_x *1f, 1f, 1f);
        }
    }

}
