using BulletNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    //[SerializeField] [Range(0.1f,10f)] private float bulletSpeed = 20f;
    [SerializeField] private Bullet bulletProperty;
    public Bullet SetBulletPpoperty {set => bulletProperty = value; }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right*bulletProperty.Speed, ForceMode2D.Impulse);

    }



}
