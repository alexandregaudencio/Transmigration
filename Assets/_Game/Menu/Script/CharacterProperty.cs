using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] [Min(0)] private float DashStamin; //sync
        [SerializeField] [Min(0)] private float mana; //sync
        [SerializeField] private Weapon weapon;
        
        public float Speed { get => speed; set => speed = value; }
        public float Defense { get => defense; set => defense = value; }
        public float HP { get => hp; set => hp = value; }
        public float DashStamin1 { get => DashStamin; set => DashStamin = value; }
        public float DashSpeed { get => dashSpeed; set => dashSpeed = value; }
        public Weapon Weapon { get => weapon; set => weapon = value; }

    }
}

