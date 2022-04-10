using Photon.Pun;
using PlayerDataNamespace;
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
    private InputJoystick inputJoystick;
    public WeaponArmRotation WeaponArmRotation { get => weaponArmRotation;}
    public WeaponArmShooter WeaponArmShooter { get => weaponArmShooter; }
   
    [SerializeField] private SpriteRenderer DirectionalArrow;


    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        weaponArmShooter = GetComponent<WeaponArmShooter>();
        weaponArmRotation = GetComponent<WeaponArmRotation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputJoystick = GetComponentInParent<InputJoystick>();
    }

    private void OnEnable()
    {
        weaponArmShooter.R_UseButtonDownAction += SpriterenderActive;
    }

    private void OnDisable()
    {
        weaponArmShooter.R_UseButtonDownAction -= SpriterenderActive;

    }

    //eviar apra os colegas

    public void SpriterenderActive(bool value)
    {

        spriteRenderer.enabled = value;
        DirectionalArrow.enabled = value;
 
        if (value) FlipYHandWeapon();
    }


    private void FlipYHandWeapon()
    {
        if(inputJoystick.GetRAxisKey)
        {
            spriteRenderer.flipY = (inputJoystick.RAxis.x < 0);

        }
    }

}
