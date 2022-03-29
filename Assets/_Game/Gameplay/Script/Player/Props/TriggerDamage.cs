using BulletNamespace;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    //TODO: TROCAR PARA DEFINIR O BULLETPROPERTY QUANDO INSTANCIA A BALA
    [SerializeField] private Bullet bulletProperty;

    //public List<string> collisionTagsList;
    private PhotonView PV;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == this.gameObject.layer) return;
        
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(bulletProperty.Damage);

    }


}






