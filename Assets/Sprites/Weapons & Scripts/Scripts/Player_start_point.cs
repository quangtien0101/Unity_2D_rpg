using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_start_point : MonoBehaviour
{
    //controll the facing of the player
    
    private player_controller the_player;
    private Camera_controller the_Camera;

    public Vector2 startDirection;
    public string point_name;

    // Start is called before the first frame update
    void Start()
    {
        //controll the player start point
        the_player = FindObjectOfType<player_controller>();

        if (the_player.start_point == point_name)
        {
            the_player.transform.position = transform.position;
            the_player.last_move = startDirection;


            //controll the camera start point
            the_Camera = FindObjectOfType<Camera_controller>();
            the_Camera.transform.position = new Vector3(transform.position.x, transform.position.y, the_Camera.transform.position.z);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
