using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_switcher : MonoBehaviour
{
    private Music_manager Music_man;
    public int new_track;
    public bool switch_on_start;

    // Start is called before the first frame update
    void Start()
    {
        Music_man = FindObjectOfType<Music_manager>();

        
        if (switch_on_start)
        {
            Music_man.Switch_Track(new_track);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Music_man.Switch_Track(new_track);
            gameObject.SetActive(false);
        }
    }
}
