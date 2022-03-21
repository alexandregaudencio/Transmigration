using UnityEngine;

namespace PlayerStateMachine
{
    public abstract class State
    {
        public abstract void EnterState(PlayerController playerController, StateController stateController);
        public abstract void UpdateState(PlayerController playerController, StateController stateController);
        public abstract void FixedUpdateState(PlayerController playerController, StateController stateController);
        public abstract void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController);

    }
}

