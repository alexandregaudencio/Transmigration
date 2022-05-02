using Photon.Pun;
using PlayerDataNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WeaponArmController : MonoBehaviour
{
    private WeaponArmRotation weaponArmRotation;
    private WeaponArmShooter weaponArmShooter;
    private SpriteRenderer spriteRenderer;
    private InputJoystick inputJoystick;
    public WeaponArmRotation WeaponArmRotation { get => weaponArmRotation;}
    public WeaponArmShooter WeaponArmShooter { get => weaponArmShooter; }
   
    [SerializeField] private SpriteRenderer DirectionalArrow;


    private void Awake()
    {
        weaponArmShooter = GetComponent<WeaponArmShooter>();
        weaponArmRotation = GetComponent<WeaponArmRotation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputJoystick = GetComponentInParent<InputJoystick>();
    }

    private void OnEnable()
    {
        weaponArmShooter.R_AxisButtonDown += WeaponSpriteRenders;
    }

    private void OnDisable()
    {
        weaponArmShooter.R_AxisButtonDown -= WeaponSpriteRenders;

    }

    //eviar apra os colegas

    public void WeaponSpriteRenders(bool value)
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
