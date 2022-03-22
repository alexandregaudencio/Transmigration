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


    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        characterProperty = GetComponentInParent<PlayerController>().CharacterProperty;
        manaManager = GetComponentInParent<ManaManager>();
    }

    private void OnEnable()
    {
        shootAction += DefaultShoot;
    }
    private void OnDisable()
    {
        shootAction -= DefaultShoot;
    }
    public void ProcessWeaponShot(PlayerAudioManager audioManager)
    {
        
        if (PV.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(OnShootCoroutine());
                L_MouseButtonDownActiveAction?.Invoke(true);
            }

            if(Input.GetMouseButtonUp(0))
            {
                StopAllCoroutines();
                L_MouseButtonDownActiveAction?.Invoke(false);
            }
            //if (Input.GetMouseButtonUp(0))
            //{
            //    DefaultShoot();
            //    //PV.RPC("DefaultShoot", RpcTarget.All);
            //    audioManager.PlayAudio(audioManager.shootClip, false);
            //}
        }
    }


    [PunRPC]
    public void DefaultShoot()
    {
        GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.layer = GetComponentInParent<HPManager>().GetLayer;

    }

    private IEnumerator OnShootCoroutine()
    {
        while (isManaEnough)
        {
            shootAction?.Invoke();
            //DefaultShoot();
            yield return new WaitForSeconds(characterProperty.Weapon.CooldownInSeconds);
        }
    }


}
