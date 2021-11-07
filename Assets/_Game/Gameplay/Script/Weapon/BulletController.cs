using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private GameObject collisioneffect;

    public List<string> collisionTagsList;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer == collision.gameObject.layer) return;

            
       
        if (collisionTagsList.Contains(collision.gameObject.tag)) {

                GameObject effect = Instantiate(collisioneffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
           
        }

        //trocar isso aqui para tag específicas
        


        //TODO: destroir o effeito ao final da animação do efeito.
    }


}
