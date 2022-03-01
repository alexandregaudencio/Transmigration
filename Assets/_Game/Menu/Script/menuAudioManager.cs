using Photon.Pun;
using UnityEngine;

public class menuAudioManager : MonoBehaviourPunCallbacks
{

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    public void PlayAudio(AudioClip clip/*, bool isSync*/)
    {
        AudioSource.clip = clip;
        //AudioSource.loop = onLoop;
        AudioSource.Play();

    }


    [PunRPC] 
    private void PunPlayAudio(AudioClip clip)
    {

        AudioSource.clip = clip;
        //AudioSource.loop = onLoop;
        AudioSource.Play();

    }

}
