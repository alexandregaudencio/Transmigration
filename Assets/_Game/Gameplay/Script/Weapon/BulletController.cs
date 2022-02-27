using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject collisioneffect;

    public List<string> collisionTagsListIgnore;
    [SerializeField] private List<string> organicObjectTagList;

    private PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collisionTagsListIgnore.Contains(collision.tag) && this.gameObject.layer != collision.gameObject.layer)
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
        GameObject effect = PhotonNetwork.Instantiate(collisioneffect.name, transform.position, Quaternion.identity);
        effect.GetComponent<EffectController>().PlayAudioClip(organicObjectTagList.Contains(targetTag));
        PhotonNetwork.Destroy(this.gameObject);
        //PV.RPC("SendDestroy", RpcTarget.All);
    }


    //[PunRPC] 
    //public void SendDestroy()
    //{
    //    Destroy(this.gameObject);
    //}



}
