using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.Data.Score
{
    [CreateAssetMenu(fileName ="PlayerScore", menuName = "PlayerScore")]

    public class PlayerScore : ScriptableObject, IScore
    {
        //[SerializeField] private Pla
        [SerializeField] private int killCount;
        [SerializeField] private int deathCount;
        [SerializeField] private float damageAmount;
        public int KillCount { get => killCount; set => killCount = value; }
        public int DeathCount { get => deathCount; set => deathCount = value; }
        public float DamageAmount { get => damageAmount; set => damageAmount = value; }

        public int score => KillCount;

        public void addDamageAmount(float damage)
        {
            damageAmount += damage;
        }

        public void IncreaseDeathCount()
        {
            deathCount++;
        }

        public void IncreaseKillCount()
        {
            killCount++;
        }

        public void ResetScore()
        {
            killCount = 0;
            deathCount = 0;
            damageAmount = 0;
        }

    }
}

