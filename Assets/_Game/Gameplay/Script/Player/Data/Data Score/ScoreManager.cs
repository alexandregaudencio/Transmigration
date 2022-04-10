using DamageableNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Data.Score
{
    public class ScoreManager : MonoBehaviour, IScore
    {
        [SerializeField] private PlayerScore playerScore;
        public PlayerScore PlayerScore { get => playerScore; set => playerScore = value; }


        private void Start()
        {
            PlayerScore.ResetScore();
        }
        public void addDamageAmount(float damage)
        {
            PlayerScore.DamageAmount += damage;
        }

        public void IncreaseDeathCount()
        {
            PlayerScore.DeathCount++;
        }

        public void IncreaseKillCount()
        {
            PlayerScore.KillCount++;
        }

 


    }

}
