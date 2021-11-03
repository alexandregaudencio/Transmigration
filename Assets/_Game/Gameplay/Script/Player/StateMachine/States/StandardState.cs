using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardState : State
{
    public override void EnterState(PlayerController playerController, StateController stateController)
    {
        playerController.GetComponent<SpriteRenderer>().color = playerController.GetComponent<PlayerProperty>().GetColor;


    }

    public override void FixedUpdateState(PlayerController playerController, StateController stateController)
    {
        if (playerController.photonView.IsMine)
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


        }
    }

    public override void OnCollisionEnter(PlayerController playerController, Collision2D collision, StateController stateController)
    {
    }

    public override void UpdateState(PlayerController playerController, StateController stateController)
    {
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
