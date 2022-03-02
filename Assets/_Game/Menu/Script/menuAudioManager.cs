using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class menuAudioManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private AudioClip menuMusic;

    private AudioSource audioSource;
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayAudio(menuMusic);
    }


    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }

    public void PlayAudio(AudioClip clip/*, bool isSync*/)
    {
        AudioSource.clip = clip;
        //AudioSource.loop = onLoop;
        AudioSource.Play();

    }

    public void PlaySyncAudio(AudioSource audioSource, AudioClip clip, RpcTarget targets, bool isLoop) 
    {
        PV.RPC("PunPlayAudio", targets, audioSource, isLoop);
    }


    [PunRPC] 
    private void PunPlayAudio(AudioSource audioSource, AudioClip clip, bool isLoop)
    {

        audioSource.loop = isLoop;
        audioSource.clip = clip;
        //AudioSource.loop = onLoop;
        audioSource.Play();

    }

}
