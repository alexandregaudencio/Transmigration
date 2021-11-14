using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioManager : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip shootClip;
    public AudioClip hurtClip;
    public AudioClip deathClip;
    public AudioClip meditationClip;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    
    }


    public void PlayAudio(AudioClip audio, bool onLoop)
    {
        audioSource.clip = audio;
        audioSource.loop = onLoop;
        audioSource.Play();

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
