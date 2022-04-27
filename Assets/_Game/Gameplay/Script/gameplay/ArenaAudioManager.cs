using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaAudioManager : MonoBehaviour
{
    private AudioSource[] audioSourceOrdered;


    private void Awake()
    {
        audioSourceOrdered = GetComponents<AudioSource>();

    }

    void Start()
    {
        PlayArenaMusicInOrder();
    }

    private void PlayArenaMusicInOrder()
    {
        for (int i = 0; i < audioSourceOrdered.Length; i++)
        {
            float previousAudioClipLength = (i==0) ? 0 : audioSourceOrdered[i - 1].clip.length;
            audioSourceOrdered[i].PlayDelayed(previousAudioClipLength);
        }
        //firstAudioSource.Play();
        //secondAudioSource.PlayDelayed(firstAudioSource.clip.length);
    }
}
