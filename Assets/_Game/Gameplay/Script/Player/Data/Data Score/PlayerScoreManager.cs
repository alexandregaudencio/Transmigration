using CharacterNamespace;
using DamageableNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Data.Score
{
    public class PlayerScoreManager : MonoBehaviour, IScore
    {
        [SerializeField] private PlayerScore playerScore;
        private CharacterProperty characterProperty;
        public PlayerScore PlayerScore { get => playerScore; set => playerScore = value; }

        private void Awake()
        {
            characterProperty = GetComponent<PlayerController>().CharacterProperty;
        }

        private void Start()
        {
            PlayerScore.ResetScore();
            PlayerScore.CharacterProperty = characterProperty;
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
