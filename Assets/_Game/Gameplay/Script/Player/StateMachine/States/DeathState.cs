using Photon.Pun;
using System.Collections;
using UnityEngine;

public class DeathState : State
{
    public override void EnterState(PlayerController playerController, StateController stateController)
    {
        stateController.StartCoroutine(ReturnToNormalState(stateController, playerController));

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
          playerController.photonView.RPC("SwitchComponent", RpcTarget.All, false);
        yield return new WaitForSeconds(3);
        playerController.photonView.RPC("SwitchComponent", RpcTarget.All, true);
        stateController.TransitionToState(stateController.ListedStates.standardState);
    }





}
