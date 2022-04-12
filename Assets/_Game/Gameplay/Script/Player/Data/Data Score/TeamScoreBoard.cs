using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Player.Data.Score
{
    public class TeamScoreBoard : MonoBehaviour
    {

        [SerializeField] private List<PlayerScore> playerScoresTeam;
        private TMP_Text text_score;
        private float teamScore = 0;
        

        private void Awake()
        {
            text_score = GetComponent<TMP_Text>();
        }

        public List<PlayerScore> PlayerScoresTeam { get => playerScoresTeam; set => playerScoresTeam = value; }

        private void OnEnable()
        {
            foreach (PlayerScore playerScore in playerScoresTeam)
            {
                playerScore.scoreUpdated += UpdateTeamScore;
            }
        }

        private void OnDisable()
        {
            foreach (PlayerScore playerScore in playerScoresTeam)
            {
                playerScore.scoreUpdated -= UpdateTeamScore;
            }
        }

        private void UpdateTeamScore(float value)
        {
            teamScore += value;
            text_score.SetText(teamScore.ToString());
        }

    }
}

