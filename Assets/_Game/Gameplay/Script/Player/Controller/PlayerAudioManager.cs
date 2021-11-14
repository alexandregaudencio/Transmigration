using Photon.Pun;
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

    private PhotonView PV;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PV = GetComponent<PhotonView>();
    }


    public void PlayAudio(AudioClip audio, bool onLoop)
    {
        audioSource.clip = audio;
        audioSource.loop = onLoop;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }




}
