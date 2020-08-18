using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_manager : MonoBehaviour
{
    public AudioSource player_hurt;
    public AudioSource player_attack;
    public AudioSource player_dead;

    private static bool sfxman_exist;

    // Start is called before the first frame update
    void Start()
    {
        if (!sfxman_exist)
        {
            sfxman_exist = true;
            DontDestroyOnLoad(transform.gameObject);

        }
        else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
