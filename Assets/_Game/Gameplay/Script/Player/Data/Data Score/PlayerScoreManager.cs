
using PlayerDataNamespace;
using UnityEngine;

namespace Player.Data.Score
{
    public class PlayerScoreManager : MonoBehaviour, IScore
    {
        [SerializeField] private PlayerScore[] playerScoreList;
        [SerializeField] private PlayerScore playerScore;
        public PlayerScore lastPlayerDamager;
        private InputJoystick inputJoystick;
        private HPManager hPManager;
        public PlayerScore PlayerScore { get => playerScore; set => playerScore = value; }

        private void Awake()
        {
            inputJoystick = GetComponent<InputJoystick>();
            hPManager = GetComponent<HPManager>();
        }

        private void OnEnable()
        {
            hPManager.hpEmpty += lastPlayerDamager.IncreaseKillCount;
            hPManager.hpEmpty += playerScore.IncreaseDeathCount;
        }
        private void OnDisable()
        {
            hPManager.hpEmpty-= lastPlayerDamager.IncreaseKillCount;
            hPManager.hpEmpty -= playerScore.IncreaseDeathCount;
        }
        private void Start()
        {
            PlayerScore = playerScoreList[(int)inputJoystick.Joystick];
            PlayerScore.ResetScore();
        }
        public void addDamageAmount(float damage)
        {
            PlayerScore.DamageAmount += damage;
        }

        public void IncreaseDeathCount()
        {
            PlayerScore.IncreaseDeathCount();
        }

        public void IncreaseKillCount()
        {
            PlayerScore.IncreaseKillCount();
        }

 


    }

}
