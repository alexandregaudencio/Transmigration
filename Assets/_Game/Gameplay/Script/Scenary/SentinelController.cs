using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelController : MonoBehaviour
{
    [SerializeField] [Range(0,5)] private float bulletSpawnInterval;

    [SerializeField] private GameObject sentinelBullet;
    [SerializeField] private Transform weaponBase;
    [SerializeField] private Transform targetMass;
    [SerializeField] private List<Transform> targetCharacters;

    private bool TargetOnVision => (targetCharacters.Count > 0) ? true : false;


    private Quaternion targetRotation
    {
        get
        {
            Vector2 direction = targetDirection - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }
    private Vector3 targetDirection
    {

        get
        {
            Vector2 vectorResult = Vector2.zero;
            float distanceResult = 0f;
            foreach (Transform t in targetCharacters)
            {
                if (Vector3.Distance(t.position, transform.position) > distanceResult)
                {
                    vectorResult = t.position;
                }
            }
            return vectorResult;
        }
    }


    void Start()
    { 
        StartCoroutine(WaitToShoot());
    }


    private void Update()
    {
        Debug.Log(TargetOnVision);
        //weaponBase.rotation = targetRotation;

    }

    private IEnumerator WaitToShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnInterval);
            Shoot();
        }

    }

    private void Shoot()
    {
 
        //só pra ilustrar
        if (TargetOnVision)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            //mira
            weaponBase.rotation = targetRotation;
            //atira
            GameObject bullet = Instantiate(sentinelBullet, targetMass.position, targetMass.rotation);
            bullet.layer = gameObject.layer;

            //INSTANCIAR EFEITOS AQUI
            //espera

        }
        //else
        //{
        //    GetComponent<SpriteRenderer>().color = Color.white;
        //}

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsDifferentLayer(collision.gameObject.layer) && !collision.gameObject.CompareTag("bullet"))
        {
            targetCharacters.Add(collision.gameObject.transform);
            GetComponent<SpriteRenderer>().color = Color.red;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (IsDifferentLayer(collision.gameObject.layer) && !collision.gameObject.CompareTag("bullet"))
        {
            targetCharacters.Remove(collision.gameObject.transform);
            GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

    private bool IsDifferentLayer(LayerMask layer)
    {

        if(this.gameObject.layer == LayerMask.NameToLayer("TeamA") && layer.value == LayerMask.NameToLayer("TeamB"))
        {
            return true;
        }
        else if(this.gameObject.layer == LayerMask.NameToLayer("TeamB") && layer.value == LayerMask.NameToLayer("TeamA"))
        {
            return true;
        }
        else
        {
            return false;
        }
                
   }



 
}
