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
        //public override void ExitState(PlayerController playerController)
        //{
        //    Debug.Log("ExitState: standard");
        //}
        public override void FixedUpdateState(PlayerController playerController, StateController stateController)
        {
            
            Movement(playerController);
            
            playerController.WeaponBase.WeaponArmShooter.ProcessWeaponShot(playerController.AudioManager);
            //playerController.WeaponBase.WeaponSpriteActivation();
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerController.transform.position;
            bool flipState = (direction.x < 0.00f) ? true : false;
            playerController.photonView.RPC("SetRendererFlipX", RpcTarget.All, flipState);

        }

        public override void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController)
        {
        }

        public override void UpdateState(PlayerController playerController, StateController stateController)
        {
            //playerController.Animator.SetFloat("Horizontal", playerController.PlayerRigidbody2D.velocity.x);
            //playerController.Animator.SetFloat("Vertical", playerController.PlayerRigidbody2D.velocity.y);
            //playerController.Animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            //playerController.Animator.SetFloat("Vertical", Input.GetAxis("Vertical"));


            bool Waking = Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f;
            playerController.Animator.SetBool("preWalking", Waking);

            if (!Waking) playerController.Animator.SetBool("walking", false);


            ProcessDashInput(playerController, stateController);
            ProcessPrayInput(stateController);

        }

        private void ProcessDashInput(PlayerController playerController ,StateController stateController)
        {
            if (Input.GetKeyDown(KeyCode.Space) )
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
            playerController.PlayerRigidbody2D.velocity = clampedDirection * Time.fixedDeltaTime * speed;
        }
        private Vector2 clampedDirection
        {
            get
            {
                Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                return  Vector2.ClampMagnitude(inputDirection, 1);

            }
        }
        //void VerticalMove(PlayerController playerController)
        //{
        //    playerController.PlayerRigidbody2D.velocity = new Vector2(playerController.PlayerRigidbody2D.velocity.x, Input.GetAxis("Vertical") *playerController.CharacterProperty.Speed * Time.fixedDeltaTime);
        //}

        //private void Movement(PlayerController playerController)
        //{

        //    float speed = playerController.CharacterProperty.Speed;

        //    playerController.PlayerRigidbody2D.velocity = direction * speed * Time.fixedDeltaTime;
        //}

        //private Vector2 direction
        //{
        //    get
        //    {
        //        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //    }
        //}

    }

}

