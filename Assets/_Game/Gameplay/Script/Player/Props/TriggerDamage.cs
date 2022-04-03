using BulletNamespace;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

namespace DamageableNamespace
{
    public class TriggerDamage : MonoBehaviour
    {
        private BulletProperty bulletProperty;
        private void Awake()
        {
            bulletProperty = GetComponent<BulletProperty>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.layer == gameObject.layer) return;

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(bulletProperty.Damage);

        }


    }

}






