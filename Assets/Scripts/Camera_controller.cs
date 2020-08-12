using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    public GameObject follow_target;
    private Vector3 target_position;
    public float move_speed;
    private static bool cameraExist;

    // Start is called before the first frame update
    void Start()
    {
        if (!cameraExist)
        {
            cameraExist = true;
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
        target_position = new Vector3(follow_target.transform.position.x, follow_target.transform.position.y, transform.position.z);

        // make the camera move to new position
        transform.position = Vector3.Lerp(transform.position, target_position, move_speed * Time.deltaTime);
        
    }
}
