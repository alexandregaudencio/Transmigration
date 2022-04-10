using System.Collections.Generic;
using UnityEngine;

namespace Player.Data.Score
{
    [CreateAssetMenu(fileName = "Score", menuName = "score")]
    public class ScoreBoard : MonoBehaviour
    {

        [SerializeField] private List<PlayerScore> playerScoresTeamA;
        [SerializeField] private List<PlayerScore> playerScoresTeamB;

        public List<PlayerScore> PlayerScoresTeamA { get => playerScoresTeamA; set => playerScoresTeamA = value; }
        public List<PlayerScore> PlayerScoresTeamB { get => playerScoresTeamB; set => playerScoresTeamB = value; }


    }
}

