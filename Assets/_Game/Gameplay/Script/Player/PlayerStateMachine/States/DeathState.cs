using System.Collections;
using UnityEngine;

namespace PlayerStateMachine
{
    public class DeathState : State
    {
        public override void EnterState(PlayerController playerController, StateController stateController)
        {
            //Debug.Log("DeathState Enter");
            //playerController.Animator.Play("death");
            playerController.StartCoroutine(ReturnToNormalState(stateController, playerController));
            playerController.AudioManager.PlayAudio(playerController.AudioManager.deathClip, false);

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
            playerController.SwitchComponent(false);
            yield return new WaitForSeconds(3/*GameConfigs.instance.TimeToRespawn*/);
            //habilita tudo;
            playerController.SwitchComponent(true);
            playerController.HPManager.ResetHP();
            stateController.TransitionToState(stateController.ListedStates.standardState);


        }





    }

}
