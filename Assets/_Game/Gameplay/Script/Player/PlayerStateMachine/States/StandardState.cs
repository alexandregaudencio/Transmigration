using UnityEngine;

namespace PlayerStateMachine
{
    public class StandardState : State
    {
        //float period = 0;
        //float frequency = 0;
        //float angularFrequency = 0;
        //float elapsedTime = 0;
        //float amplitude = 0;
        //float phase = 0;

        float time = 0;
        public override void EnterState(PlayerController playerController, StateController stateController)
        {
            playerController.Animator.Play("idle");

        }

        public override void FixedUpdateState(PlayerController playerController, StateController stateController)
        {
            bool walking = playerController.InputJoystick.LAxis != Vector2.zero;
            playerController.Animator.SetBool("preWalking", walking);

            if (walking)
            {
                Movement(playerController);
            }
            else
            {
                playerController.Animator.SetBool("walking", false);
                ProcessFloatingMovement(playerController);
            }


            
            

            playerController.WeaponArmController.WeaponArmShooter.ProcessRAxisInput();
            playerController.WeaponArmController.WeaponArmShooter.ProcessLAxisInput();

            playerController.WeaponArmController.WeaponArmShooter.ProcessShootInput();



            playerController.SpriteRenderer.flipX = ProcessInputsToFlipRenderer(playerController);

        }

        public bool ProcessInputsToFlipRenderer(PlayerController playerController)
        {
            Vector2 Rdirection = playerController.InputJoystick.RAxis;
            Vector2 Ldirection = playerController.InputJoystick.LAxis;
            if(Rdirection != Vector2.zero)
            {
                bool isRAxisFlipX = (Rdirection.x < 0.00f) ? true : false;
                return isRAxisFlipX;
            } else
            {
                bool isLAxisFlipX = (Ldirection.x < 0.00f) ? true : false;
                return isLAxisFlipX;
            }

        }

        public override void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController)
        {
        }

        public override void UpdateState(PlayerController playerController, StateController stateController)
        {
            ProcessDashInput(playerController, stateController);
            ProcessPrayInput(playerController, stateController);
        }

        private void ProcessDashInput(PlayerController playerController ,StateController stateController)
        {
            if (playerController.InputJoystick.dashInputDown)
            {
                bool canDash = playerController.DahsManager.CanSpentStamin && 
                    playerController.InputJoystick.LAxisRaw != Vector2.zero;
                if (canDash) {
                    stateController.TransitionToState(stateController.ListedStates.dashState);

                }
            }


        }

        private void ProcessPrayInput(PlayerController playerController, StateController stateController)
        {
            if (Input.GetKeyDown(playerController.InputJoystick.TriangleInput))
                stateController.TransitionToState(stateController.ListedStates.meditateState);  
        }

        private void ProcessFloatingMovement(PlayerController playerController)
        {
            time += Time.fixedDeltaTime;
            playerController.PlayerRigidbody2D.velocity = new Vector2(0, Mathf.Sin(2 * time));
        }



        private void Movement(PlayerController playerController)
        {

            float speed = playerController.CharacterProperty.Speed;
            playerController.PlayerRigidbody2D.velocity = playerController.InputJoystick.LAxis * Time.fixedDeltaTime * speed;
        }

    }

}

