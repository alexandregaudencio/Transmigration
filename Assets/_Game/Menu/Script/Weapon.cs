using BulletNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponNamespace
{
    [CreateAssetMenu(menuName = "new Weapon", fileName = "weapon")]
    public class Weapon : ScriptableObject
    {

        [SerializeField] [Min(0)] private float damage;
        [SerializeField] [Min(0)] private float cooldownMs;
        [SerializeField] [Range(0,100)] private int manaRecoveryPercentage;
        [SerializeField] private Bullet bullet;

        public float Damage { 
            get => damage*GameConfigs.instance.BulletDamageScale; 
            set => damage = value; 
        }
        public float CooldownMs { get => cooldownMs; set => cooldownMs = value; }
        public int ManaRecoveryPercentage { get => manaRecoveryPercentage; set => manaRecoveryPercentage = value; }
        public Bullet Bullet { get => bullet;}
    }

}

