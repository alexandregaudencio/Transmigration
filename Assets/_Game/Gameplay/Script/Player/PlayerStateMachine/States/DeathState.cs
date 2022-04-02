using Photon.Pun;
using System.Collections;
using UnityEngine;

namespace PlayerStateMachine
{
    public class DeathState : State
    {
        public override void EnterState(PlayerController playerController, StateController stateController)
        {
            //if(playerController.PV.IsMine)
            //{
            //playerController.Animator.Play("death");
            stateController.StartCoroutine(ReturnToNormalState(stateController, playerController));
            playerController.AudioManager.PlayAudio(playerController.AudioManager.deathClip, false);
            //}

            //playerController.GetComponent<Collider2D>().enabled = false;
        }


        public override void FixedUpdateState(PlayerController playerController, StateController stateController)
        {

        }

        public override void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController)
        {

        }

        public override void UpdateState(PlayerController playerController, StateController stateController)
        {

        }



        private IEnumerator ReturnToNormalState(StateController stateController, PlayerController playerController)
        {
            //Desabilita tudo;
            yield return new WaitForSeconds(GameConfigs.instance.TimeToRespawn);
            //habilita tudo;
            stateController.TransitionToState(stateController.ListedStates.standardState);
            //playerController.HPManager.ResetPlayerPrps();


        }





    }

}
