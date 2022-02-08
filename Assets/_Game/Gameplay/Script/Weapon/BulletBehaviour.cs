using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] [Range(0.1f,10f)] private float bulletSpeed = 20f;

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right*bulletSpeed, ForceMode2D.Impulse);

    }


}
