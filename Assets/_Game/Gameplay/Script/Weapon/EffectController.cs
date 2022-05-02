
using Photon.Pun;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class EffectController : MonoBehaviour
{
    private AudioSource audioSource;
    //0: não organico   //1: organico
    [SerializeField] private AudioClip[] audioList;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(bool isTargetDamageable)
    {
        if(isTargetDamageable)
        {
            audioSource.clip = audioList[0];
            audioSource.Play();
        } 
        //else
        //{
        //    audioSource.clip = (AudioClip)audioList.GetValue(1);
        //    audioSource.Play();
        //}

    }

    public void DestroyEffect()
    {
            Destroy(gameObject);
    }
}
