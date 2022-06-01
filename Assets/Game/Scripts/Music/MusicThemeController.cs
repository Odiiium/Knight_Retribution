using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicThemeController : MonoBehaviour
{
    internal static float musicVolume = .5f;
    internal static AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = musicVolume;
        
    }
    public static void ChangeVolume(float value)
    {
        audioSource = FindObjectOfType<MusicThemeController>().GetComponent<AudioSource>();
        audioSource.volume = value;
        musicVolume = value;
    }
}
