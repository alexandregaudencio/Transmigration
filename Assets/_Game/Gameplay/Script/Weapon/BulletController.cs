using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private GameObject collisioneffect;

    public List<string> collisionTagsListIgnore;
    [SerializeField] private List<string> organicObjectTagList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collisionTagsListIgnore.Contains(collision.tag) && this.gameObject.layer != collision.gameObject.layer)
        {
            OnBulletCollision(collision.gameObject.tag);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collisionTagsListIgnore.Contains(collision.tag) && this.gameObject.layer != collision.gameObject.layer)
        {
            OnBulletCollision(collision.gameObject.tag);
        }

    }

    void OnBulletCollision(string targetTag)
    {


        GameObject effect = Instantiate(collisioneffect, transform.position, Quaternion.identity);
        effect.GetComponent<EffectController>().PlayAudioClip(organicObjectTagList.Contains(targetTag));
        
        Destroy(this.gameObject);
        Destroy(effect, 2f);
    }



}
