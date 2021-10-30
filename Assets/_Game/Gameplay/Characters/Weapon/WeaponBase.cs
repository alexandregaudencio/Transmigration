using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public float rotateSpeed = 5f;



    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    void Update()
    {
        if(GetComponentInParent<PhotonView>().IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Shoot();

                GetComponent<SpriteRenderer>().enabled = false;

            }
        }
       
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);



    }




    void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GetComponentInParent<Transform>().position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.fixedDeltaTime);


        GetComponent<SpriteRenderer>().flipY = (direction.x < 0.0000f);
    }
}
