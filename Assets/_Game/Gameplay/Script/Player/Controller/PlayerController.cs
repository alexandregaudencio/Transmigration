﻿using CharacterNamespace;
using Player.Data.Score;
using PlayerDataNamespace;
using PlayerStateMachine;
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
public class PlayerController : MonoBehaviour
{
    public GameObject shield;
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
    private PlayerScore lastToDamage;
    [SerializeField] private CharacterProperty characterProperty;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    [SerializeField] private GameObject canvasOverPlayer;
    private PlayerScore playerScore;
    public Rigidbody2D PlayerRigidbody2D { get => RigidBody2D; set => RigidBody2D = value; }
    public StateController StateController { get => stateController; set => stateController = value; }
    public HPManager HPManager { get => hpManager; set => hpManager = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public WeaponArmController WeaponArmController { get => weaponArmController; set => weaponArmController = value; }
    public PlayerAudioManager AudioManager { get => audioManager; set => audioManager = value; }
    public CharacterProperty CharacterProperty { get => characterProperty; set => characterProperty = value; }
    public DashManager DahsManager { get => dashManager; set => dashManager = value; }
    public InputJoystick InputJoystick { get => inputJoystick; set => inputJoystick = value; }
    public PlayerScore PlayerScore => playerScore;

    //public string Team { get => PV.Controller.GetPhotonTeam().Name; }
    //public LayerMask GetLayer => LayerMask.NameToLayer((Team == "Blue") ? "TeamB" : "TeamA");

    private Vector3 spawnPosition = new Vector2(0, -3);
    public Vector3 SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
    public PlayerScore LastToDamage { get => lastToDamage; set => lastToDamage = value; }

    private void Awake()
    {

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
        playerScore = GetComponent<PlayerScoreManager>().PlayerScore;
    }

    private void OnEnable()
    {
        hpManager.hpEmpty += stateController.GoDeathState;
        weaponArmController.WeaponArmShooter.R_UseButtonDownAction += IdleAttackAnimationTransition;
    }
    private void OnDisable()
    {
        hpManager.hpEmpty -= stateController.GoDeathState;
        weaponArmController.WeaponArmShooter.R_UseButtonDownAction -= IdleAttackAnimationTransition;


    }
    public void SetCharacterRendererFlipX( bool flipXState)
    {
        if (inputJoystick.LAxis == Vector2.zero)
        {
            SpriteRenderer.flipX = flipXState;
        }
        //weaponSpriteRenderer.flipX = flipXState;
    }

    public void SwitchPlayerActivityComponent(bool value)
    {
        canvasOverPlayer.SetActive(value);
        //spriteRenderer.enabled = value;
        weaponArmController.enabled = value;
        //Animator.SetBool("dead", !value);
        BoxCollider2D.enabled = value;
    }

    public void CanPlayWalkAnimation()
    {
        animator.SetBool("walking", true);
    }

    public void ResetPlayerPosition()
    {
        transform.position = SpawnPosition;
    }

    public void IdleAttackAnimationTransition(bool value)
    {
        animator.SetBool("idle-atk", value);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            shield.SetActive(true);
        }
    }
}

