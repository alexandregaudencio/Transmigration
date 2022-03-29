using System.Collections;
using UnityEngine;

namespace PlayerStateMachine
{
    public class DashState : State
    {
        public override void EnterState(PlayerController playerController, StateController stateController)
        {
            //StopAllCoroutines();
            playerController.DahsManager.spentStamin();
            playerController.PlayerRigidbody2D.velocity = clampedDirection * playerController.CharacterProperty.DashSpeed;
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
            yield return new WaitForSeconds(0.3f);
            stateController.TransitionToState(stateController.ListedStates.standardState);


        }

        private Vector2 clampedDirection
        {
            get
            {
                Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                return Vector2.ClampMagnitude(inputDirection, 1);

            }
        }
    }

}
