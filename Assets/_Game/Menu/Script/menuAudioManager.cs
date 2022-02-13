using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;

    //public AudioClip[] Clips;


    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    void Awake()
    {

    }


    public void PlayAudio(AudioClip id, bool isSync)
    {
        AudioSource.clip = id;
        //AudioSource.loop = onLoop;
        AudioSource.Play();

    }

}
