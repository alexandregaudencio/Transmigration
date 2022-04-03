using CharacterNamespace;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using PlayerDataNamespace;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(StateController))]
[RequireComponent(typeof(HPManager))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(DashManager))]
[RequireComponent(typeof(ManaManager))]
[RequireComponent(typeof(InputJoystick))]
public class PlayerController : MonoBehaviourPunCallbacks
{
    private Rigidbody2D RigidBody2D;
    private StateController stateController;
    private HPManager hpManager;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private WeaponArmController weaponArmController;
    private PlayerAudioManager audioManager;
    private DashManager dashManager;
    private InputJoystick inputJoystick;

    [SerializeField] private CharacterProperty characterProperty;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    [SerializeField] private GameObject canvasOverPlayer;
    
    private PhotonView pV;
    public Rigidbody2D PlayerRigidbody2D { get => RigidBody2D; set => RigidBody2D = value; }
    //public float Speed { get => speed; set => speed = value; }
    public StateController StateController { get => stateController; set => stateController = value; }
    public HPManager HPManager { get => hpManager; set => hpManager = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }
    //public float DashSpeed { get => dashSpeed; set => dashSpeed = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public PhotonView PV { get => pV; set => pV = value; }
    public WeaponArmController WeaponArmController { get => weaponArmController; set => weaponArmController = value; }
    public PlayerAudioManager AudioManager { get => audioManager; set => audioManager = value; }
    public CharacterProperty CharacterProperty { get => characterProperty; set => characterProperty = value; }
    public DashManager DahsManager { get => dashManager; set => dashManager = value; }
    public InputJoystick InputJoystick { get => inputJoystick; set => inputJoystick = value; }

    //public string Team { get => PV.Controller.GetPhotonTeam().Name; }
    //public LayerMask GetLayer => LayerMask.NameToLayer((Team == "Blue") ? "TeamB" : "TeamA");


    void Awake()
    {

        PV = GetComponent<PhotonView>();
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
        StateController = GetComponent<StateController>();
        HPManager = GetComponent<HPManager>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();
        weaponArmController = GetComponentInChildren<WeaponArmController>();
        audioManager = GetComponent<PlayerAudioManager>();
        dashManager = GetComponent<DashManager>();
        inputJoystick = GetComponent<InputJoystick>();

    }

    void Start()
    {

        //gameObject.layer = GetLayer;
    }

    [PunRPC]
    public void SetRendererFlipX( bool flipXState)
    {
        GetComponent<SpriteRenderer>().flipX = flipXState;
        //weaponSpriteRenderer.flipX = flipXState;
    }

    [PunRPC]
    public void SwitchComponent(bool value)
    {
        canvasOverPlayer.SetActive(value);
        Animator.SetBool("dead", !value);
        BoxCollider2D.enabled = value;
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

