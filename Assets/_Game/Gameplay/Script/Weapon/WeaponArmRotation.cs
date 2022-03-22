using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmRotation : MonoBehaviour
{
    public float rotateSpeed = 10f;

    private PhotonView PV;
    private Transform parentTransform;

    private event Action weaponRotationEvent;
    public event Action mouseMoveEvent;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        parentTransform = GetComponentInParent<Transform>();
    }


    private void OnMouseMoved()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, mouseRotation, rotateSpeed * Time.fixedDeltaTime);
        //FLIP DO SPRITE DO BRACINHO
    }

    private Vector3 mousePosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private Quaternion mouseRotation
    {
        get
        {
            float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    private Vector2 mouseDirection
    {
        get
        {
            return mousePosition - parentTransform.position;

        }

    }

    public Quaternion MouseRotation => mouseRotation;


    void FixedUpdate()
    {
        OnMouseMoved();
    }


}
