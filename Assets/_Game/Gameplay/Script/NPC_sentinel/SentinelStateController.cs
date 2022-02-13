using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelStateController : MonoBehaviour
{

        public ListedSentinelStates listedStates;
        private SentinelState currentSentinelState;
        private SentinelController sentinelController;

        private void Awake()
        {
            listedStates = new ListedSentinelStates();
            sentinelController = this.gameObject.GetComponent<SentinelController>();
        }

        
        private void OnEnable()
        {
            TransitionToState(listedStates.sleepSentinelState);
        }


        public virtual void TransitionToState(SentinelState state)
        {
        //if (PV.IsMine)
        //{
            currentSentinelState.ExitState(sentinelController);
            currentSentinelState = state;
            currentSentinelState.EnterState(sentinelController);
            //}

        }


        private void Update()
        {
                currentSentinelState.UpdateState(sentinelController);
        }


    
}
