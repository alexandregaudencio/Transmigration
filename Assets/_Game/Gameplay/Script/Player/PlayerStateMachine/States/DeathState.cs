using System.Collections;
using UnityEngine;

namespace PlayerStateMachine
{
    public class DeathState : State
    {
        public override void EnterState(PlayerController playerController, StateController stateController)
        {
            playerController.LastToDamage.IncreaseKillCount();
            playerController.PlayerScore.IncreaseDeathCount();
            playerController.Animator.SetTrigger("dead");
            playerController.StartCoroutine(ReturnToNormalState(stateController, playerController));
            //playerController.AudioManager.PlayAudio(playerController.AudioManager.DeathClip, false);

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
            playerController.SwitchPlayerActivityComponent(false);
            yield return new WaitForSeconds(3);
            //habilita tudo;
            playerController.SwitchPlayerActivityComponent(true);
            playerController.HPManager.ResetHP();
            playerController.ResetPlayerPosition();
            stateController.TransitionToState(stateController.ListedStates.standardState);


        }





    }

}
