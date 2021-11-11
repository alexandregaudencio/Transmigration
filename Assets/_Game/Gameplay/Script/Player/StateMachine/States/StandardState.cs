using Photon.Pun;
using UnityEngine;

public class StandardState : State
{
    public override void EnterState(PlayerController playerController, StateController stateController)
    {
        playerController.GetComponent<SpriteRenderer>().color = playerController.GetComponent<PlayerProperty>().GetColor;
        playerController.Animator.Play("Idle_Gato");

    }

    public override void FixedUpdateState(PlayerController playerController, StateController stateController)
    {

            HorizontalMove(playerController);
            VerticalMove(playerController);

            //text.text = Mathf.Round(playerRigidbody2D.velocity.y).ToString();

            //FLIP
            //if (direction.x < 0.0000f)
            //{

            //    transform.rotation = Quaternion.Euler(0, 180f, 0);
            //}
            //else
            //{
            //    transform.rotation = Quaternion.Euler(0, 0f, 0);

            //}

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



        //if(Input.GetKeyDown(KeyCode.LeftArrow) ||
        //    Input.GetKeyDown(KeyCode.LeftArrow) ||
        //    Input.GetKeyDown(KeyCode.RightArrow) ||
        //    Input.GetKeyDown(KeyCode.UpArrow) ||
        //    Input.GetKeyDown(KeyCode.DownArrow) ||
        //    Input.GetKeyDown(KeyCode.A) ||
        //    Input.GetKeyDown(KeyCode.W) ||
        //    Input.GetKeyDown(KeyCode.S) ||
        //    Input.GetKeyDown(KeyCode.D)
        //    )
        //    {
        //        playerController.Animator.Play("walk");
        //    }

        //if (Input.GetKeyUp(KeyCode.LeftArrow) ||
        //    Input.GetKeyUp(KeyCode.LeftArrow) ||
        //    Input.GetKeyUp(KeyCode.RightArrow) ||
        //    Input.GetKeyUp(KeyCode.UpArrow) ||
        //    Input.GetKeyUp(KeyCode.DownArrow) ||
        //    Input.GetKeyUp(KeyCode.A) ||
        //    Input.GetKeyUp(KeyCode.W) ||
        //    Input.GetKeyUp(KeyCode.S) ||
        //    Input.GetKeyUp(KeyCode.D)
        //    )
        //    {
        //        playerController.Animator.Play("Idle_Gato");
        //    }



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
