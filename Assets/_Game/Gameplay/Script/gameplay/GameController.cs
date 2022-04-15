using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public enum GameStates
    {
        NULL,
        START,
        BATTLE,
        FINISH
    }

    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private List<GameplayStateClassHandler> gameStateList;

        //[SerializeField]
        private GameStates actualGameState = GameStates.NULL;
        public GameStates ActualGameState { get => actualGameState; set => actualGameState = value; }

        public event Action<GameStates> gameStateChange;
        private void Start()
        {
            ChangeGameState(GameStates.START);

        }



        public void ChangeGameState(GameStates state )
        {
            if (actualGameState == state) return;
            foreach(GameplayStateClassHandler gameState in gameStateList)
            {
                //gameState.DisableObjects(gameState.State != state);
                gameState.EnableClassController(gameState.State == state);

            }
            actualGameState = state;
        }

    }


}
