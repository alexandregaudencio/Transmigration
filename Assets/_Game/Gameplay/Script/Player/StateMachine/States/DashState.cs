using System.Collections;

using UnityEngine;

public class DashState : State
{
    public override void EnterState(PlayerController playerController, StateController stateController)
    {
         playerController.PlayerRigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerController.DashSpeed, playerController.PlayerRigidbody2D.velocity.y);
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
        yield return new WaitForSeconds(1);
        stateController.TransitionToState(stateController.ListedStates.standardState);


    }

}
