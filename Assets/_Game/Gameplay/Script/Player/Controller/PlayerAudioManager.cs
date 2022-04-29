﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAudioEvent
{
    DASH,
    SHOT,
    HURT,
    DEATH,
}

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private List<PlayerAudio> playerAudios;
    //[SerializeField] private AudioClip shootClip;
    //[SerializeField] private AudioClip hurtClip;
    //[SerializeField] private AudioClip deathClip;
    //[SerializeField] private AudioClip meditationClip;

    //public AudioClip ShootClip { get => shootClip; set => shootClip = value; }
    //public AudioClip HurtClip { get => hurtClip; set => hurtClip = value; }
    //public AudioClip DeathClip { get => deathClip; set => deathClip = value; }
    //public AudioClip MeditationClip { get => meditationClip; set => meditationClip = value; }

    private Dictionary<string, AudioClip> audioDictionary= new Dictionary<string, AudioClip>();
    private void Start()
    {
        foreach (PlayerAudio playerAudio in playerAudios)
        {
            if(audioDictionary != null)
                audioDictionary.Add(playerAudio.AudioName, playerAudio.AudioClip);
        }
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(string audioEvent)
    {
        if(audioDictionary[audioEvent] != null)
        {
            audioSource.clip = audioDictionary[audioEvent];
            audioSource.Play();
        }

    }

    public void PlayAudio(AudioClip audio, bool onLoop)
    {
        audioSource.clip = audio;
        audioSource.loop = onLoop;
        audioSource.Play();
    }
    public void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
    public void StopAudio()
    {
        audioSource.Stop();
    }





}


[Serializable]
public class PlayerAudio
{

    [SerializeField] private string audioName;
    [SerializeField] private AudioClip audioClip;

    public string AudioName { get => audioName; set => audioName = value; }
    public AudioClip AudioClip { get => audioClip; set => audioClip = value; }

    public PlayerAudio(string eventName, AudioClip audioClip )
    {
        this.audioName = eventName;
        this.audioClip = audioClip;

    }



}
