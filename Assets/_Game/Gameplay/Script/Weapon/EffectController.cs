
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EffectController : MonoBehaviour
{
    AudioSource audioSource;
    //0: não organico   //1: organico
    [SerializeField] private AudioClip[] audioList;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(bool isOrganicTarget)
    {
        if(isOrganicTarget)
        {
            audioSource.clip = (AudioClip)audioList.GetValue(0);
            audioSource.Play();
        } else
        {
            audioSource.clip = (AudioClip)audioList.GetValue(1);
            audioSource.Play();
        }

    }

    public void DestroyOject()
    {
        if(GetComponent<PhotonView>().IsMine)
            PhotonNetwork.Destroy(this.gameObject);
    }
}
