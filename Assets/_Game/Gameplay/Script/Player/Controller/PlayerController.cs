using CharacterNamespace;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(StateController))]
[RequireComponent(typeof(PhotonPlayerProperty))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviourPunCallbacks
{
    private Rigidbody2D RigidBody2D;
    private StateController stateController;
    private PhotonPlayerProperty playerProperty;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private WeaponArmController weaponBase;
    private PlayerAudioManager audioManager;


    [SerializeField] private CharacterProperty characterProperty;
    //[SerializeField] private float speed;
    //[SerializeField] private int maxYVelocity;
    //[SerializeField] private float dashSpeed;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    [SerializeField] private GameObject billboard;
    

    //[Header("Jetpack Settings")]
    //[SerializeField] private int minFloatingToJatpack;
    //[SerializeField] private int jatpackImpulse;
    //[SerializeField] private KeyCode jetpackInput;
    //public Text text;

    //public bool isGround;
    //public bool canJatpack;

    //public bool IsGround { get => isGround; set => isGround = value; }
    private PhotonView pV;
    public Rigidbody2D PlayerRigidbody2D { get => RigidBody2D; set => RigidBody2D = value; }
    //public float Speed { get => speed; set => speed = value; }
    public StateController StateController { get => stateController; set => stateController = value; }
    public PhotonPlayerProperty PlayerProperty { get => playerProperty; set => playerProperty = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }
    //public float DashSpeed { get => dashSpeed; set => dashSpeed = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public PhotonView PV { get => pV; set => pV = value; }
    public WeaponArmController WeaponBase { get => weaponBase; set => weaponBase = value; }
    public PlayerAudioManager AudioManager { get => audioManager; set => audioManager = value; }
    public CharacterProperty CharacterProperty { get => characterProperty; set => characterProperty = value; }

    //private new PhotonView photonView;

    void Awake()
    {

        PV = GetComponent<PhotonView>();
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        StateController = GetComponent<StateController>();
        PlayerProperty = GetComponent<PhotonPlayerProperty>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();
        weaponBase = GetComponentInChildren<WeaponArmController>();
        audioManager = GetComponent<PlayerAudioManager>();

    }


    [PunRPC]
    public void SetRendererFlipX( bool flipXState)
    {
        GetComponent<SpriteRenderer>().flipX = flipXState;
        //weaponSpriteRenderer.flipX = flipXState;
    }

    [PunRPC]
    public void SwitchComponent(bool value/*, Vector3 spawnPosition, Player player*/)
    {
        billboard.SetActive(value);
        Animator.SetBool("dead", !value);
        BoxCollider2D.enabled = value;
        //GetComponent<SpriteRenderer>().color = (value) ? Color.white : Color.gray;
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        //if (PhotonNetwork.LocalPlayer == targetPlayer && changedProps.ContainsKey("isDead"))
        //    if ((bool)PV.Controller.CustomProperties["isDead"])
        //    {
        //        GoToDeathState();
        //    }
        //    else
        //    {
        //        GoToStandartState();
        //    }

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

