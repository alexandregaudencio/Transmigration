using System;
using UnityEngine;

namespace CharacterNamespace
{
    public class ManaManager : MonoBehaviour
    {
        [Min(0)] private float mana;
        [Min(0)] private float maxMana;
        private CharacterProperty characterProperty;
        private WeaponArmShooter WeaponArmShooter;

        public float Mana { get => mana; }
        public float MaxMana { get => maxMana; }
        public float ManaFraction => mana / maxMana;
        
        public event Action manaChangesAction;

        private void Start()
        {
            mana = characterProperty.Mana;
            maxMana = characterProperty.MaxMana;
        }

        public void SpentMana()
        {
            mana -= characterProperty.Weapon.Bullet.ManaCost;
            manaChangesAction?.Invoke();
        }

        private void OnEnable()
        {
            WeaponArmShooter.shootAction += SpentMana;
        }

        private void OnDisable()
        {
            WeaponArmShooter.shootAction -= SpentMana;
        }

        private void FixedUpdate()
        {
            ManaRecovery();
        }

        public void ManaRecovery()
        {
            if (mana <= MaxMana)
            {
                float manaToIncrease = ((float)characterProperty.Weapon.ManaRecoveryPercentagePerSecond / 100);
                float newManaAmough = mana + MaxMana * manaToIncrease;
                mana = Mathf.Lerp(mana, newManaAmough, Time.fixedDeltaTime);
                manaChangesAction?.Invoke();
            }
        }
    }
}

