using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditateState : State
{
    public override void EnterState(PlayerController playerController, StateController stateController)
    {
        playerController.Animator.Play("meditate");
        playerController.PlayerRigidbody2D.velocity = Vector2.zero;
        playerController.Animator.SetBool("meditating", true);


    }

    public override void FixedUpdateState(PlayerController playerController, StateController stateController)
    {

    }

    public override void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController)
    {

    }

    public override void UpdateState(PlayerController playerController, StateController stateController)
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            playerController.Animator.SetBool("meditating", false);
            stateController.TransitionToState(stateController.ListedStates.standardState);
        }
    }
}
