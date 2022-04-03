using Photon.Pun;
using PlayerDataNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmRotation : MonoBehaviour
{
    public float rotateSpeed = 10f;
    private InputJoystick inputJoystick;
    private event Action weaponRotationEvent;
    public event Action mouseMoveEvent;

    private void Awake()
    {
        inputJoystick = GetComponentInParent<InputJoystick>();
    }


    private void WeaponRotation()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, WeaponInputRotation, rotateSpeed * Time.fixedDeltaTime);
        //FLIP DO SPRITE DO BRACINHO
    }

    public Quaternion WeaponInputRotation
    {
        get
        {
            float angle = Mathf.Atan2(inputJoystick.RVerticalAxis, inputJoystick.RHorizontalAxis) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    void FixedUpdate()
    {
        if(inputJoystick.GetRAxisKey) WeaponRotation();
    }


}
