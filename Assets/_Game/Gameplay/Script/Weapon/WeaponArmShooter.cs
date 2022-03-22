using CharacterNamespace;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmShooter : MonoBehaviour
{
    private PhotonView PV;
    private ManaManager manaManager;
    private CharacterProperty characterProperty;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    public event Action<bool> L_MouseButtonDownActiveAction;
    public event Action shootAction;

    bool isManaEnough => (manaManager.Mana >= characterProperty.Weapon.Bullet.ManaCost);
    bool canShoot = true;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        characterProperty = GetComponentInParent<PlayerController>().CharacterProperty;
        manaManager = GetComponentInParent<ManaManager>();
    }

    private void OnEnable()
    {
        //shootAction += DefaultShoot;
        L_MouseButtonDownActiveAction += DefaultShoot;
    }
    private void OnDisable()
    {
        //shootAction -= DefaultShoot;
        L_MouseButtonDownActiveAction += DefaultShoot;

    }


    public void ProcessWeaponShoot(PlayerAudioManager audioManager)
    {
        if(PV.IsMine)
            L_MouseButtonDownActiveAction?.Invoke(Input.GetMouseButton(0));
    }


    //[PunRPC]
    public void DefaultShoot(bool mouseButtonDown)
    {
        if(isManaEnough && canShoot && mouseButtonDown)
        {
            GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.layer = GetComponentInParent<PlayerController>().GetLayer;
            canShoot = false;
            StartCoroutine(Cooldown());
            shootAction?.Invoke();

        }

    }

    //private IEnumerator Cooldown()
    //{
    //    while (isManaEnough && canShoot)
    //    {
    //        //DefaultShoot();
    //        yield return new WaitForSeconds(characterProperty.Weapon.CooldownInSeconds);
    //    }
    //}

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(characterProperty.Weapon.CooldownInSeconds);
        canShoot = true;
    }



}
