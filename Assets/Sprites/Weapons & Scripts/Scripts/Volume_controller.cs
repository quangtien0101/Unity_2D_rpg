using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume_controller : MonoBehaviour
{
    private AudioSource the_audio;
    private float audio_level;
    public float default_audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAudioLevel(float volume)
    {
        audio_level = default_audio * volume;
        the_audio.volume = audio_level;
    }
}
