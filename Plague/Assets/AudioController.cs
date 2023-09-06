using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;

    public void PlayStepAudio()
    {
        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length - 1)], 1);
    }
}
