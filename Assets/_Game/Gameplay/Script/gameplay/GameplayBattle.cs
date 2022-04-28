using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class GameplayBattle : MonoBehaviour
    {

        [SerializeField] private Timer gameplayTimer;
        //[SerializeField] private GameObject canvas_HUD;
        [SerializeField] private GameObject canvas_FinalUserInterface;
        [SerializeField] private GameController gameController;
        [SerializeField] private List<GameObject> stateGameObjects;

        //private event Action GameplayTimeOver;
        private void OnEnable()
        {
            gameplayTimer.timeOver += OnGameplayTimerOver;
            OnGameplayBattle(true);
 
        }
        private void OnDisable()
        {
            gameplayTimer.timeOver -= OnGameplayTimerOver;
            OnGameplayBattle(false);
        }

        private void Start()
        {
            canvas_FinalUserInterface.SetActive(false);
        }

        private void LateUpdate()
        {
            ProcessScoreboardView();
        }

        private void ProcessScoreboardView()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                canvas_FinalUserInterface.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                canvas_FinalUserInterface.SetActive(false);

            }

        }

        private void OnGameplayTimerOver()
        {
            gameController.ChangeGameState(GameStates.FINISH);
        }

        private void OnGameplayBattle(bool value)
        {
            foreach (GameObject gameObject in stateGameObjects)
            {
                gameObject.SetActive(value);
            }

        }
    }
}


