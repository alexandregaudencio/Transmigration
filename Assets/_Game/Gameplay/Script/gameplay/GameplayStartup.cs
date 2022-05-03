using Managers;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameplayStartup : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private GameController gameController;
        [SerializeField] private List<GameObject> stateGameObjects;
        
        private void Start()
        {
            //gameController = GetComponent<GameController>();
        }
        private void OnEnable()
        {
            OnGameplayStartup(true);
            timer.onTimeOver += OnStartupTimerOver;
        }

        private void OnDisable()
        {
            OnStartupTimerOver();
            OnGameplayStartup(false);
            timer.onTimeOver -= OnStartupTimerOver;
        }

        private void OnStartupTimerOver()
        {
            gameController.ChangeGameState(GameStates.BATTLE);
        }

        private void OnGameplayStartup(bool value)
        {
            foreach (GameObject gameObject in stateGameObjects)
            {
                gameObject.SetActive(value);
            }

        }
    }

}
