using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_manager : MonoBehaviour
{
    public static bool music_man_exist;

    public AudioSource[] music_tracks;

    public int current_track;
    public bool music_can_play;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!music_man_exist)
        {
            music_man_exist = true;
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
        if (music_can_play)
        {
            if (!music_tracks[current_track].isPlaying)
            {
                music_tracks[current_track].Play();
            }
        }
        else
        {
            music_tracks[current_track].Stop();
        }
    }

    public void Switch_Track(int newTrack)
    {
        music_tracks[current_track].Stop();
        current_track = newTrack;
        music_tracks[current_track].Play();
    }
}
