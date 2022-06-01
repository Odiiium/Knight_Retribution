using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClipArray;
    [SerializeField] internal AudioClip[] hurtClips;

    static internal int clipIndex;

    internal AudioSource audioSource;


    private void Start()
    {
        clipIndex = Random.Range(0, audioClipArray.Length);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = MusicThemeController.musicVolume;
        audioSource.PlayOneShot(audioClipArray[clipIndex]);
        StartCoroutine(WaitForNextMusicTheme(audioClipArray[clipIndex].length));
    }

    public IEnumerator WaitForNextMusicTheme(float time)
    {
        clipIndex++;
        if (clipIndex == audioClipArray.Length)
        {
            clipIndex = 0;
        }
        yield return new WaitForSeconds(time);
        audioSource.PlayOneShot(audioClipArray[clipIndex]);
        StartCoroutine(WaitForNextMusicTheme(audioClipArray[clipIndex].length));

    }
}


