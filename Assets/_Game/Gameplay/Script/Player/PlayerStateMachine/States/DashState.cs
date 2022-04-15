using System.Collections;
using UnityEngine;

namespace PlayerStateMachine
{
    public class DashState : State
    {
        public override void EnterState(PlayerController playerController, StateController stateController)
        {
            //StopAllCoroutines();
            playerController.Animator.Play("dash");
            playerController.DahsManager.spentStamin();
            playerController.PlayerRigidbody2D.velocity = playerController.InputJoystick.LAxisRaw*playerController.CharacterProperty.DashSpeed;

            playerController.StartCoroutine(GoToStaminaState(stateController));
        }


        public override void FixedUpdateState(PlayerController playerController, StateController stateController)
        {

        }

        public override void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController)
        {


        }

        public override void UpdateState(PlayerController playerController, StateController stateController)
        {
            //float currentAnimationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;


        }

        IEnumerator GoToStaminaState(StateController stateController)
        {
            yield return new WaitForSeconds(0.5f);
            stateController.TransitionToState(stateController.ListedStates.standardState);


        }

     

    }

}
