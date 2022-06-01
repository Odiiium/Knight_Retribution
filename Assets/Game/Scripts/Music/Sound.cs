using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    internal static float effectsVolume = .5f;
    internal static AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = effectsVolume;
    }

    public static void ChangeEffectsVolume(float value)
    {
        audioSource = FindObjectOfType<Sound>().GetComponent<AudioSource>();
        audioSource.volume = value;
        effectsVolume = value;
    }
}
