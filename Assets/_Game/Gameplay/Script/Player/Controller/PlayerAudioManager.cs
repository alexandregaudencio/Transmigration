﻿using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip meditationClip;

    public AudioClip ShootClip { get => shootClip; set => shootClip = value; }
    public AudioClip HurtClip { get => hurtClip; set => hurtClip = value; }
    public AudioClip DeathClip { get => deathClip; set => deathClip = value; }
    public AudioClip MeditationClip { get => meditationClip; set => meditationClip = value; }

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
