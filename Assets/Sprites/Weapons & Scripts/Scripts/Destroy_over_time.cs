using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_over_time : MonoBehaviour
{
    public float time_to_destroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_to_destroy -= Time.deltaTime;

        if (time_to_destroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
