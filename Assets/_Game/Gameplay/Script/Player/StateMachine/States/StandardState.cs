using Photon.Pun;
using UnityEngine;

public class StandardState : State
{
    public override void EnterState(PlayerController playerController, StateController stateController)
    {
        //playerController.GetComponent<SpriteRenderer>().color = playerController.GetComponent<PlayerProperty>().GetColor;
        playerController.Animator.Play("Idle_Gato");

    }

    public override void FixedUpdateState(PlayerController playerController, StateController stateController)
    {

            HorizontalMove(playerController);
            VerticalMove(playerController);
            playerController.WeaponBase.ProcessWeaponActivation();

            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerController.transform.position;
            bool flipState = (direction.x < 0.00f) ? true : false;
            playerController.photonView.RPC("SetRendererFlipX", RpcTarget.All, flipState);


        //}
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




        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateController.TransitionToState(stateController.ListedStates.dashState);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            stateController.TransitionToState(stateController.ListedStates.meditateState);
        }


    }




    private void HorizontalMove(PlayerController playerController)
    {

        playerController.PlayerRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * playerController.Speed, playerController.PlayerRigidbody2D.velocity.y);
    }

    void VerticalMove(PlayerController playerController)
    {
        playerController.PlayerRigidbody2D.velocity = new Vector2(playerController.PlayerRigidbody2D.velocity.x, Input.GetAxis("Vertical") *playerController.Speed * Time.fixedDeltaTime);
    }

}
