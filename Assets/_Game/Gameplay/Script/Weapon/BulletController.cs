using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject collisioneffect;

    [SerializeField] private List<string> collisionTagsToIgnore;
    [SerializeField] private List<string> collisionTagsToDetect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collisionTagsToIgnore.Contains(collision.tag) && gameObject.layer != collision.gameObject.layer)
        {
            OnBulletCollision(collision.gameObject.tag);

        }
    }


    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!collisionTagsListIgnore.Contains(collision.tag) && this.gameObject.layer != collision.gameObject.layer)
    //    {
    //        OnBulletCollision(collision.gameObject.tag);
    //    }

    //}




    void OnBulletCollision(string targetTag)
    {
        bool isDamageable = collisionTagsToDetect.Contains(targetTag);
        if(collisioneffect != null)
        {
            GameObject effect = Instantiate(collisioneffect, transform.position, Quaternion.identity);
            //effect.GetComponent<EffectController>().PlayAudioClip(isDamageable);
        }

        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);

    }

}
