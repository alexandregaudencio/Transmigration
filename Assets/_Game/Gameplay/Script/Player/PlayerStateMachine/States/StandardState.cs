using Photon.Pun;
using System;
using UnityEngine;

namespace PlayerStateMachine
{
    public class StandardState : State
    {
        public override void EnterState(PlayerController playerController, StateController stateController)
        {
            playerController.Animator.Play("Idle_Gato");

        }

        public override void FixedUpdateState(PlayerController playerController, StateController stateController)
        {
            
            Movement(playerController);
            

            playerController.WeaponArmController.WeaponArmShooter.ProcessRAxisInput();
            playerController.WeaponArmController.WeaponArmShooter.ProcessShootInput();

            Vector2 direction =  playerController.InputJoystick.RAxis;

            
            bool isFlipX = (direction.x < 0.00f) ? true : false;
            if( playerController.InputJoystick.GetRAxisKey) playerController.SpriteRenderer.flipX = isFlipX;

        }

        public override void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController)
        {
        }

        public override void UpdateState(PlayerController playerController, StateController stateController)
        {

            bool Waking = playerController.InputJoystick.LHorizontalAxis != 0.0f || playerController.InputJoystick.LVerticalAxis != 0.0f;
            playerController.Animator.SetBool("preWalking", Waking);

            if (!Waking) playerController.Animator.SetBool("walking", false);

            ProcessDashInput(playerController, stateController);
            ProcessPrayInput(stateController);

        }

        private void ProcessDashInput(PlayerController playerController ,StateController stateController)
        {
            if (playerController.InputJoystick.dashInputDown)
                if(playerController.DahsManager.CanDash)
                    stateController.TransitionToState(stateController.ListedStates.dashState); 
        }

        private void ProcessPrayInput(StateController stateController)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                stateController.TransitionToState(stateController.ListedStates.meditateState);  
        }



        private void Movement(PlayerController playerController)
        {

            float speed = playerController.CharacterProperty.Speed;
            playerController.PlayerRigidbody2D.velocity = playerController.InputJoystick.LAxis * Time.fixedDeltaTime * speed;
        }

    }

}

