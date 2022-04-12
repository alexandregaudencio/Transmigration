using CharacterNamespace;
using DamageableNamespace;
using Photon.Pun;
using Player.Data.Score;
using PlayerDataNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmShooter : MonoBehaviour
{
    private ManaManager manaManager;
    private CharacterProperty characterProperty;
    private InputJoystick inputJoystick;
    [SerializeField] private Transform bulletSpawnPoint;
    /*[SerializeField] */private PlayerScoreManager scoreManager;

    /*[SerializeField]*/
    private GameObject bulletPrefab => characterProperty.Weapon.Bullet.BulletPrefab;

    public event Action<bool> R_UseButtonDownAction;
    public event Action<bool> L_UseButtonDownAction;

    public event Action shootAction;

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

    }

    private void OnEnable()
    {
        shootAction += OnShoot;

    }
    private void OnDisable()
    {
        shootAction -= OnShoot;

    }
    public void ProcessShootInput()
    {
        if (inputJoystick.getShootInput) DefaultShoot();
    }
    public void ProcessRAxisInput()
    {
            R_UseButtonDownAction?.Invoke(inputJoystick.GetRAxisKey);
    }
    public void ProcessLAxisInput()
    {
        L_UseButtonDownAction?.Invoke(inputJoystick.GetLAxisKey);

    }
    public void DefaultShoot()
    {
        if(isManaEnough && cooldownRelease && weaponArmActive)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.layer = ShooterLayer;
            cooldownRelease = false;
            StartCoroutine(Cooldown());
            shootAction?.Invoke();
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
        //animations, audios, effeccts...
    }


}
