using System;
using UnityEngine;
using WeaponNamespace;

namespace CharacterNamespace
{
    
    [CreateAssetMenu(fileName ="Character", menuName = "new Character")]
    public class CharacterProperty : ScriptableObject
    {
        [SerializeField] [Min(0)] private float speed;
        [SerializeField] [Min(0)] private float defense;
        [SerializeField] [Min(0)] private float dashSpeed;

        [SerializeField] [Min(0)] private float hp; //sync
        [SerializeField] [Min(0)] private float dashStaminCost; //sync
        [SerializeField] [Min(0)] private float dashStamin; //sync
        [SerializeField] [Range(0,100)] private float dashStaminRecoveryPercentagemInSeconds;
        [SerializeField] [Min(0)] private float mana; //sync
        [Min(0)] private float maxMana;
        [Min(0)] private float maxDashStamin;
        [SerializeField] private Weapon weapon;


        public float Speed { get => speed; set => speed = value; }
        public float Defense { get => defense; set => defense = value; }
        public float HP { get => hp;}
        public float DashStamin { get => dashStamin; set => dashStamin = value; }
        public float DashSpeed { get => dashSpeed; set => dashSpeed = value; }
        public Weapon Weapon { get => weapon; set => weapon = value; }
        public float Mana { get => mana; set => mana = value; }
        
        public float MaxMana { get => maxMana; }
        public float MaxDashStamin { get => maxDashStamin;}
        public float DashStaminCost { get => dashStaminCost; set => dashStaminCost = value; }
        public float DashStaminRecoveryPercentagemInSeconds { get => dashStaminRecoveryPercentagemInSeconds; set => dashStaminRecoveryPercentagemInSeconds = value; }

        private void OnEnable()
        {
            maxMana = mana;
            maxDashStamin = dashStamin;
            //Debug.Log(MaxMana);
        }
    }
}

