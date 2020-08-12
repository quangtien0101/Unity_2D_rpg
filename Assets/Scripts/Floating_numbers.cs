using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floating_numbers : MonoBehaviour
{
    public float move_speed;
    public int damages;
    public Text display_number;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        display_number.text = "" + damages;
        transform.position = new Vector3(transform.position.x, transform.position.y + (move_speed * Time.deltaTime), transform.position.z);

    }
}
