using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletController : MonoBehaviour
{

    [SerializeField] private GameObject collisioneffect;

    public List<string> collisionTagsList;

    AudioSource audioSource;
    public AudioClip targetsAudioClip;
    public AudioClip otherAudioClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collisionTagsList.Contains(collision.gameObject.tag))
        {

            BulletArrived();
        } 

    }

    void BulletArrived()
    {
        audioSource.clip = targetsAudioClip;
        audioSource.Play();
        GameObject effect = Instantiate(collisioneffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 3f);
    }


}
