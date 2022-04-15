using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class GameplayFinish : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private List<GameObject> stateGameObjects;

        private void OnEnable()
        {
            OnGameplayFinish(true);
        }

        private void OnDisable()
        {
            OnGameplayFinish(false);
        }


        private void OnGameplayFinish(bool value)
        {
            foreach (GameObject gameObject in stateGameObjects)
            {
                gameObject.SetActive(value);
            }

        }


    }
}

