
using PlayerDataNamespace;
using UnityEngine;

namespace Player.Data.Score
{
    public class PlayerScoreManager : MonoBehaviour, IScore
    {
        [SerializeField] private PlayerScore[] playerScoreList;
       [SerializeField] private PlayerScore playerScore;
        private PlayerScore lastPlayerDamager;
        private InputJoystick inputJoystick;
        private HPManager hPManager;
        public PlayerScore PlayerScore { get => playerScore; set => playerScore = value; }
        public PlayerScore PlayerScore1 { get => playerScore; set => playerScore = value; }
        public PlayerScore LastPlayerDamager { get => lastPlayerDamager; set => lastPlayerDamager = value; }

        private void Awake()
        {
            inputJoystick = GetComponent<InputJoystick>();
            hPManager = GetComponent<HPManager>();
        }

        private void OnEnable()
        {
            //hPManager.hpEmpty += lastPlayerDamager.IncreaseKillToDamager;
            //hPManager.hpEmpty += playerScore.IncreaseDeathToPlayer;
        }
        private void OnDisable()
        {
            //hPManager.hpEmpty-= lastPlayerDamager.IncreaseKillToDamager;
            //hPManager.hpEmpty -= playerScore.IncreaseDeathToPlayer;
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

        public void IncreaseDeathToPlayer()
        {
            PlayerScore.IncreaseDeathToPlayer();
        }

        public void IncreaseKillToDamager()
        {
            lastPlayerDamager.IncreaseKillToDamager();
        }

 


    }

}
