using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WeaponArmController : MonoBehaviour
{

    private PhotonView PV;
    private WeaponArmRotation weaponArmRotation;
    private WeaponArmShooter weaponArmShooter;
    private SpriteRenderer spriteRenderer;
    public WeaponArmRotation WeaponArmRotation { get => weaponArmRotation;}
    public WeaponArmShooter WeaponArmShooter { get => weaponArmShooter; }
    

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        weaponArmShooter = GetComponent<WeaponArmShooter>();
        weaponArmRotation = GetComponent<WeaponArmRotation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        weaponArmShooter.L_MouseButtonDownActiveAction += SpriterenderActive;
    }

    private void OnDisable()
    {
        weaponArmShooter.L_MouseButtonDownActiveAction -= SpriterenderActive;

    }

    //eviar apra os colegas
    [PunRPC]
    public void SpriterenderActive(bool value)
    {
        spriteRenderer.enabled = value;
    }

    private void Update()
    {
        
        GetComponent<SpriteRenderer>().flipY = (WeaponArmRotation.mousePosition.x < transform.position.x);

    }
}
