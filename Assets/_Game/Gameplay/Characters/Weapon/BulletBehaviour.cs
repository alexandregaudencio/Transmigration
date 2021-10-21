using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 20f;


    [SerializeField] private GameObject collisioneffect;


    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right*bulletSpeed, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(collisioneffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        //TODO: destroir o effeito ao final da animação do efeito.

    }



}
