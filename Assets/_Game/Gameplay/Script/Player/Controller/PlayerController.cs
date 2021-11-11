using Photon.Pun;
using Photon.Realtime;

using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(StateController))]
[RequireComponent(typeof(PlayerProperty))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviourPunCallbacks
{
    Rigidbody2D RigidBody2D;
    StateController stateController;
    PlayerProperty playerProperty;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    Animator animator;

    [SerializeField] private float speed;
    [SerializeField] private int maxYVelocity;
    [SerializeField] private float dashSpeed;

    [Header("Jetpack Settings")]
    //[SerializeField] private int minFloatingToJatpack;
    //[SerializeField] private int jatpackImpulse;
    //[SerializeField] private KeyCode jetpackInput;
    //public Text text;

    public bool isGround;
    //public bool canJatpack;

    public bool IsGround { get => isGround; set => isGround = value; }
    public PhotonView PV;
    public Rigidbody2D PlayerRigidbody2D { get => RigidBody2D; set => RigidBody2D = value; }
    public float Speed { get => speed; set => speed = value; }
    public StateController StateController { get => stateController; set => stateController = value; }
    public PlayerProperty PlayerProperty { get => playerProperty; set => playerProperty = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }
    public float DashSpeed { get => dashSpeed; set => dashSpeed = value; }
    public Animator Animator { get => animator; set => animator = value; }

    //private new PhotonView photonView;

    void Awake()
    {

        PV = GetComponent<PhotonView>();
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        StateController = GetComponent<StateController>();
        PlayerProperty = GetComponent<PlayerProperty>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();

    }

    //void ProcessJatpack()
    //{

    //    if (isGround)
    //    {
    //        if (Input.GetKeyDown(jetpackInput))
    //        {
    //            playerRigidbody2D.AddForce(new Vector2(playerRigidbody2D.velocity.x, impulse), ForceMode2D.Impulse);
    //        }
    //    } 



    //    if(canJatpack)
    //    {

    //        if (Input.GetKey(jetpackInput) ) {
    //            if(Mathf.Round(playerRigidbody2D.velocity.y) <= maxYVelocity)
    //            {
    //                playerRigidbody2D.AddForce(new Vector2(0, jatpackImpulse), ForceMode2D.Force);
    //                GetComponent<SpriteRenderer>().color = Color.blue;
    //            }

    //        } else
    //        {
    //            GetComponent<SpriteRenderer>().color = Color.yellow;

    //        }
    //    }




    //    if(!IsGround && Mathf.Round(playerRigidbody2D.velocity.y) < minFloatingToJatpack && !canJatpack)
    //    {

    //        canJatpack = true;
    //        GetComponent<SpriteRenderer>().color = Color.yellow;

    //    } 


    //}

    [PunRPC]
    public void SetRendererFlipX( bool flipXState)
    {
        GetComponent<SpriteRenderer>().flipX = flipXState;
    }

    [PunRPC]
    public void SwitchComponent(bool value/*, Vector3 spawnPosition, Player player*/)
    {
        BoxCollider2D.enabled = value;
        //RigidBody2D.gravityScale = (value) ? gravitScale : 0;
        GetComponent<SpriteRenderer>().color = (value) ? Color.white : Color.black;

    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("ground"))
    //    {
    //        isGround = true;
    //        //canJatpack = false;
    //        //GetComponent<SpriteRenderer>().color = Color.white;

    //    }
    //}


    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("ground"))
    //    {
    //        isGround = false;
    //    }
    //}

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (PV.Controller == targetPlayer && changedProps.ContainsKey("isDead"))
            if ((bool) PV.Controller.CustomProperties["isDead"])
            {
                GoToDeathState();
            }
            else
            {
                GoToStandartState();
            }

    }
    

    public void GoToDeathState()
    {
        StateController.TransitionToState(StateController.ListedStates.deathState);

    }

    public void GoToStandartState()
    {
        StateController.TransitionToState(StateController.ListedStates.deathState);

    }


    public void CanPlayWalkAnimation()
    {
        animator.SetBool("walking", true);
    }


}

