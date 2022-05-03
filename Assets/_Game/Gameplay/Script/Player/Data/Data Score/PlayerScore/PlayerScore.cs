using CharacterNamespace;
using PlayerDataNamespace;
using System;
using UnityEngine;


namespace Player.Data.Score
{
    [CreateAssetMenu(fileName ="PlayerScore", menuName = "PlayerScore")]

    public class PlayerScore : ScriptableObject, IScore
    {
        [SerializeField] private Joystick playerJoystick;
        [SerializeField] private int killCount;
        [SerializeField] private int deathCount;
        [SerializeField] private float damageAmount;
        [SerializeField] private CharacterProperty characterProperty;
        public int KillCount { get => killCount; set => killCount = value; }
        public int DeathCount { get => deathCount; set => deathCount = value; }
        public float DamageAmount { get => damageAmount; set => damageAmount = value; }
        public event Action increaseKill;
        public event Action increaseDeath;
        public event Action<float> damageUpdate;
        public event Action<float> scoreUpdated;

        //public float score => KillCount*100+damageAmount-deathCount*50;
        private float killPoints = 50;
        private float deathPoints = -10;
        public Joystick PlayerJoystick { get => playerJoystick; set => playerJoystick = value; }

        public void addDamageAmount(float damage)
        {
            damageAmount += damage;
            damageUpdate?.Invoke(damage);
            scoreUpdated?.Invoke(damage);
        }

        public void IncreaseDeathToPlayer()
        {
            deathCount++;
            increaseDeath?.Invoke(); 
            scoreUpdated?.Invoke(0);

        }

        public void IncreaseKillToDamager()
        {
            killCount++;
            increaseKill?.Invoke(); 
            scoreUpdated?.Invoke(killPoints);

        }

        public void ResetScore()
        {
            killCount = 0;
            deathCount = 0;
            damageAmount = 0;
        }

        private void OnDisable()
        {
            characterProperty = null;
        }
    }
}

