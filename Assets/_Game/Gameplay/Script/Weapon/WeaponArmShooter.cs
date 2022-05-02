using CharacterNamespace;
using DamageableNamespace;
using Photon.Pun;
using Player.Data.Score;
using PlayerDataNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponArmShooter : MonoBehaviour
{
    private ManaManager manaManager;
    private CharacterProperty characterProperty;
    private InputJoystick inputJoystick;
    [SerializeField] private Transform bulletSpawnPoint;
    private PlayerController playerController;
    /*[SerializeField] */private PlayerScoreManager scoreManager;
    private PlayerAudioManager audioManager;

    /*[SerializeField]*/
    private GameObject bulletPrefab => characterProperty.Weapon.Bullet.BulletPrefab;
    
    public event Action<bool> R_AxisButtonDown;
    public event Action<bool> L_AxisButtonDown;

    public UnityEvent onShoot;

    private bool isManaEnough => (manaManager.Mana >= characterProperty.Weapon.Bullet.ManaCost);
    private bool cooldownRelease = true;
    private bool weaponArmActive => inputJoystick.GetRAxisKey;
    private LayerMask ShooterLayer => gameObject.transform.parent.gameObject.layer;
    private void Awake()
    {

        //PV = GetComponent<PhotonView>();
        characterProperty = GetComponentInParent<PlayerController>().CharacterProperty;
        inputJoystick = GetComponentInParent<InputJoystick>();
        manaManager = GetComponentInParent<ManaManager>();
        scoreManager = GetComponentInParent<PlayerScoreManager>();
        playerController = GetComponentInParent<PlayerController>();
        audioManager = GetComponent<PlayerAudioManager>();

    }

    private void OnEnable()
    {
        onShoot.AddListener(OnShoot);
        //shootAction += OnShoot;

    }
    private void OnDisable()
    {
        onShoot.RemoveListener(OnShoot);
        //shootAction -= OnShoot;

    }
    public void ProcessShootInput()
    {
        if (inputJoystick.getShootInput) DefaultShoot();
    }
    public void ProcessRAxisInput()
    {
            R_AxisButtonDown?.Invoke(inputJoystick.GetRAxisKey);
    }
    public void ProcessLAxisInput()
    {
        L_AxisButtonDown?.Invoke(inputJoystick.GetLAxisKey);

    }
    public void DefaultShoot()
    {
        if(isManaEnough && cooldownRelease && weaponArmActive)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.layer = ShooterLayer;
            cooldownRelease = false;
            StartCoroutine(Cooldown());
            onShoot?.Invoke();
            bullet.GetComponent<TriggerDamage>().PlayerScore = scoreManager.PlayerScore;

        }

    }


    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(characterProperty.Weapon.CooldownInSeconds);
        cooldownRelease = true;
    }

    public void OnShoot()
    {
        //playerCKontroller.AudioManager.PlayAudio(playerController.AudioManager.ShootClip, false);
        //animations, audios, effeccts...
    }


}
