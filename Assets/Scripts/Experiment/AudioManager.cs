using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickObjectSFX;
    public AudioClip experimentDone;
    public AudioClip experimentFailed;

    public void PlaySFX(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);


    }
}
