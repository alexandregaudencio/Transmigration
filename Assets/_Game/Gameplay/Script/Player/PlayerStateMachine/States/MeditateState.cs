using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStateMachine
{
    public class MeditateState : State
    {
        public override void EnterState(PlayerController playerController, StateController stateController)
        {
            playerController.Animator.SetBool("meditating", true);
            //playerController.AudioManager.PlayAudio(playerController.AudioManager.MeditationClip, true);
            //playerController.Animator.Play("meditate");
            playerController.PlayerRigidbody2D.velocity = Vector2.zero;


        }


        public override void FixedUpdateState(PlayerController playerController, StateController stateController)
        {

        }

        public override void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController)
        {

        }

        public override void UpdateState(PlayerController playerController, StateController stateController)
        {
            if (Input.GetKeyUp(playerController.InputJoystick.TriangleInput))
            {
                playerController.AudioManager.StopAudio();
                playerController.Animator.SetBool("meditating", false);
                stateController.TransitionToState(stateController.ListedStates.standardState);

            }
        }
    }

}
