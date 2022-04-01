using BulletNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private BulletProperty bulletProperty;
    private void Awake()
    {
        bulletProperty = GetComponent<BulletProperty>();
        Debug.Log("awake");
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right*bulletProperty.Speed, ForceMode2D.Impulse);
        Debug.Log(bulletProperty.Speed);
        Debug.Log("on enable");
    }

}
