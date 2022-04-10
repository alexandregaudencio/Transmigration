using BulletNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponNamespace
{
    [CreateAssetMenu(menuName = "new Weapon", fileName = "weapon")]
    public class Weapon : ScriptableObject
    {

        [SerializeField] [Min(0)] private float cooldownInSeconds;
        [SerializeField] [Range(0,100)] private int manaRecoveryPercentagePerSecond;
        [SerializeField] private Bullet bullet;


        public float CooldownInSeconds { get => cooldownInSeconds; set => cooldownInSeconds = value; }
        public int ManaRecoveryPercentagePerSecond { get => manaRecoveryPercentagePerSecond; set => manaRecoveryPercentagePerSecond = value; }
        public Bullet Bullet { get => bullet;}



    }

}

