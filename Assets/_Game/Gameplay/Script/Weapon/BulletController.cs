using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private GameObject collisioneffect;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer != collision.gameObject.layer)
        {
            GameObject effect = Instantiate(collisioneffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        //TODO: destroir o effeito ao final da animação do efeito.
    }


}
