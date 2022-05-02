using BulletNamespace;
using Photon.Pun;
using Player.Data.Score;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DamageableNamespace
{
    public class TriggerDamage : MonoBehaviour
    {
        private BulletProperty bulletProperty;
        private PlayerScore playerScore;

        public PlayerScore PlayerScore { get => playerScore; set => playerScore = value; }


        //[SerializeField] private 
        private void Awake()
        {
            bulletProperty = GetComponent<BulletProperty>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.layer == gameObject.layer) return;

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(bulletProperty.Damage);
                // isso abaixo não ta legal, "but works!"
                playerScore.addDamageAmount(bulletProperty.Damage);
                collision.gameObject.GetComponent<PlayerController>().PlayerScore = PlayerScore;
            }
            

        }


    }

}






