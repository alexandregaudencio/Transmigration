using Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class GameplayFinish : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private List<GameObject> stateGameObjects;
        [SerializeField] private GameObject text_ExitGameplay;
        private Timer timer;

        private void Awake()
        {
            timer = GetComponent<Timer>();
        }
        private void OnEnable()
        {
            timer.StartTime();
            OnGameplayFinish(true);
            timer.onTimeOver += ShowExitText;
            text_ExitGameplay.SetActive(false);
        }

        private void OnDisable()
        {
            timer.StopTime();
            OnGameplayFinish(false);
            timer.onTimeOver -= ShowExitText;

        }


        private void OnGameplayFinish(bool value)
        {
            foreach (GameObject gameObject in stateGameObjects)
            {
                gameObject.SetActive(value);
            }

        }

        private void ShowExitText()
        {
            text_ExitGameplay.SetActive(true);
        }

        private void Update()
        {
            if (timer.IsTimeOver) {
               if(Input.anyKeyDown)
                {
                    SceneManager.LoadScene(0);
                }
            } 
           
        }
    }
}

