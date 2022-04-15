using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class GameplayStateClassHandler
    {
        [SerializeField] private GameStates state;
        [SerializeField] private MonoBehaviour classController;

        public GameplayStateClassHandler(GameStates state, MonoBehaviour classController)
        {
            State = state;
            ClassController = classController;

        }

        public GameStates State { get => state; set => state = value; }
        public MonoBehaviour ClassController { get => classController; set => classController = value; }

        public void EnableClassController(bool value)
        {
            ClassController.enabled = value;
            //foreach (GameObject gameObject in ClassController)
            //{
            //    gameObject.SetActive(value);
            //}
        }

    }
}
