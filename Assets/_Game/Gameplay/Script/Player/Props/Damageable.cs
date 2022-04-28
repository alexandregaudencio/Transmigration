using System;
using UnityEngine;

namespace DamageableNamespace
{
    public class Damageable : MonoBehaviour, IDamageable
    {
        public event Action<float> TakingDamage;
        //public event Action DeathEvent;

        private PlayerController playerController;
        private HPManager hpManager;
        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            hpManager = GetComponent<HPManager>();

        }


        public void TakeDamage(float damage)
        {
            playerController.Animator.SetTrigger("hurt");
            //playerController.AudioManager.PlayAudio(playerController.AudioManager.HurtClip, false);
            hpManager.DecreaseHP(damage);
            TakingDamage?.Invoke(damage);

        }

    }

} 

