using Photon.Pun;
using UnityEngine;

public class menuAudioManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private AudioClip menuMusic;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayAudio(menuMusic);
    }


    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    public void PlayAudio(AudioClip clip)
    {
        AudioSource.clip = clip;
        //AudioSource.loop = onLoop;
        AudioSource.Play();

    }



}
