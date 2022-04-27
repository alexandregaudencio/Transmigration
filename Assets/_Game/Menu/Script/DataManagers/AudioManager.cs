using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }


    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    public void PlayAudioClip(AudioClip clip)
    {
        AudioSource.clip = clip;
        //AudioSource.loop = onLoop;
        AudioSource.Play();

    }
    public void PlayAudioClip()
    {
        AudioSource.clip = audioClip;
        //AudioSource.loop = onLoop;
        AudioSource.Play();

    }


}
