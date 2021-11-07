using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float rotateSpeed = 5f;

    PhotonView PV;


    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }


    void Update()
    {
        if (PV.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PV.RPC("SwitchSpriteRender", RpcTarget.All, true);
                //GetComponent<SpriteRenderer>().enabled = false;

            }
            if (Input.GetMouseButtonUp(0))
            {
                PV.RPC("SwitchSpriteRender", RpcTarget.All, false);
                //GetComponent<SpriteRenderer>().enabled = false;
                //TODO: ajustar o teamA 
                PV.RPC("DefaultShoot", RpcTarget.All);
            }
        }
       
    }

    [PunRPC]
    public void SwitchSpriteRender(bool value)
    {
        GetComponent<SpriteRenderer>().enabled = value;
    }

    //public void DefaultShoot(Vector2 position, Quaternion rotation, int teamLayer)  

    //RPC methods work only on scripts that are attached to the same exact GameObject
    //as the PhotonView where you call the RPC.
    //So no GetComponentInParent or GetComponentInChildren should not be used.
    [PunRPC]
    public void DefaultShoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.layer = GetComponentInParent<PlayerProperty>().GetLayer;
        //SetBulletProps(bullet);

    }

    //void SetBulletProps(GameObject bullet)
    //{
    //    //erro: dano não sendo aplicado
    //    bullet.layer = GetComponentInParent<GameObject>().layer;

    //}


    void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GetComponentInParent<Transform>().position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        if (PV.IsMine)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.fixedDeltaTime);
            GetComponent<SpriteRenderer>().flipY = (direction.x < 0.0000f);
        }
        
    }
}
