using Managers;
using Player.Data.Score;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Data.Score
{
    public class TeamScoreManager : MonoBehaviour
    {
        [SerializeField] PlayerScore[] playerScores;
        [SerializeField] private TMP_Text text_totalScore;
        [SerializeField] private TeamScoreManager anotherTeamScoreManager;
        private Image image_FinishUI;
        [Min(0)] public float totalTeamScore = 0;
        [SerializeField] private Sprite winnerSprite;
        [SerializeField] private Sprite LooserSprite;
        [SerializeField] private Timer gameplayTimer;

        private void Awake()
        {
            image_FinishUI = GetComponent<Image>();
        }

        private void Start()
        {
            gameplayTimer.onTimeOver += UpdateUIonEndGame;

            foreach (PlayerScore playerScore in playerScores)
            {
                playerScore.scoreUpdated += UpdateTeamScore;
            }
        }

        private void OnDestroy()
        {
            gameplayTimer.onTimeOver -= UpdateUIonEndGame;

            foreach (PlayerScore playerScore in playerScores)
            {
                playerScore.scoreUpdated -= UpdateTeamScore;
            }
        }

        private void UpdateTeamScore(float newAmmount)
        {
            totalTeamScore += newAmmount;
            text_totalScore.SetText(string.Format("{0:0}", totalTeamScore));
        }


        public void UpdateUIonEndGame()
        {
            bool weWin = anotherTeamScoreManager.totalTeamScore < totalTeamScore;
            image_FinishUI.sprite = weWin ? winnerSprite : LooserSprite;
        }

    }

}

