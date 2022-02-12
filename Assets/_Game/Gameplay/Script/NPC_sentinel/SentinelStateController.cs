using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SentinelController))]

public class SentinelStateController : MonoBehaviour
{

        public ListedSentinelStates listedStates;
        private SentinelState currentSentinelState;
        private SentinelController sentinelController;

        private void Awake()
        {
            listedStates = new ListedSentinelStates();
            sentinelController = GetComponent<SentinelController>();
        }

        private void Start()
        {
            TransitionToState(listedStates.sleepSentinelState);
        }


        public virtual void TransitionToState(SentinelState state)
        {
            //if (PV.IsMine)
            //{
            currentSentinelState = state;
            currentSentinelState.EnterState(sentinelController);
            //}

        }

        private void Update()
        {
            currentSentinelState.UpdateState(sentinelController);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            currentSentinelState.OnTriggerEnter2D(sentinelController, collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            currentSentinelState.OnTriggerExit2D(sentinelController, collision);
        }

    
}
