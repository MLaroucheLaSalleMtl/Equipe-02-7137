using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour
{
    public AudioMixer Music;
    // Start is called before the first frame update
    public void SetMusicVolume(float MusicVolume)
    {
        Music.SetFloat("MusicVolume", MusicVolume);

    }

   
}
