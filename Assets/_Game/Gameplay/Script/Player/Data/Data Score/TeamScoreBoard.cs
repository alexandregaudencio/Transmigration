using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Player.Data.Score
{
    public class TeamScoreBoard : MonoBehaviour
    {

        [SerializeField] private List<PlayerScore> playerScoresTeam;
        private TMP_Text text_score;
        [Min(0)] private float totalTeamScore = 0;

        Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
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

        private void UpdateTeamScore(float newAmmount)
        {
            totalTeamScore += newAmmount;
            text_score.SetText(string.Format("{0:0}", totalTeamScore));
            animator.Play("ScoreReact");
        }

    }
}

