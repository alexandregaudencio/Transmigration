using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletController : MonoBehaviour
{

    [SerializeField] private GameObject collisioneffect;

    public List<string> collisionTagsListIgnore;

    AudioSource audioSource;
    public AudioClip targetsAudioClip;
    public AudioClip otherAudioClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collisionTagsListIgnore.Contains(collision.tag))
        {
            OnBulletCollision();

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collisionTagsListIgnore.Contains(collision.tag))
        {
            OnBulletCollision();
        }

    }

    void OnBulletCollision()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        
        //definir o clip de acordo com um targetTagList ou targetLayerList
        audioSource.clip  = targetsAudioClip;
        audioSource.Play();
        GameObject effect = Instantiate(collisioneffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(effect, 2f);
    }



}
