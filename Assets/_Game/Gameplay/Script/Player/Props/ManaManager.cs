using System;
using UnityEngine;

namespace CharacterNamespace
{
    public class ManaManager : MonoBehaviour
    {
        private float mana;
        private CharacterProperty characterProperty;
        private WeaponArmShooter WeaponArmShooter;
        public float Mana { get => mana; set => mana = value; }
        public float MaxMana { get => characterProperty.MaxMana; }
        public float ManaFraction => Mana / MaxMana;
        public float manaRecoveryInSeconds => characterProperty.Weapon.ManaRecoveryPercentagePerSecond;
        public event Action manaChange;

        private void Awake()
        {
            WeaponArmShooter = GetComponentInChildren<WeaponArmShooter>();
            characterProperty = GetComponent<PlayerController>().CharacterProperty;
        }
        private void Start()
        {
            mana = characterProperty.Mana;
        }

        public void SpentMana()
        {
            Mana -= characterProperty.Weapon.Bullet.ManaCost;
            manaChange?.Invoke();
        }

        private void OnEnable()
        {
            WeaponArmShooter.onShoot.AddListener(SpentMana);
        }

        private void OnDisable()
        {
            WeaponArmShooter.onShoot.RemoveListener(SpentMana);
        }

        private void FixedUpdate()
        {
            ManaRecovery();
        }

        public void ManaRecovery()
        {
            if (Mana <= MaxMana)
            {

                float manaToIncrease = (manaRecoveryInSeconds / 100);
                float newManaAmough = Mana + MaxMana * manaToIncrease;
                Mana = Mathf.Lerp(Mana, newManaAmough, Time.fixedDeltaTime);
                //mana += manaToIncrease;
                manaChange?.Invoke();
            }
        }



    }
}

