using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelController : MonoBehaviour
{
    [SerializeField] [Range(0,5)] private float bulletSpawnInterval;
    [SerializeField] private float VisionRange;

    [SerializeField] private GameObject sentinelBullet;
    [SerializeField] private Transform weaponBase;
    [SerializeField] private Transform targetMass;
    [SerializeField] private List<Transform> targetCharacters;

    [SerializeField] private float hpSentinel;

    private bool TargetOnVision => (targetCharacters != null) ? true : false;

    public float HPSentinel { get => hpSentinel; set => hpSentinel = value; }


    void Start()
    { 
        StartCoroutine(Shoot());

    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            //só pra ilustrar
            if(TargetOnVision)
            {
                GetComponent<SpriteRenderer>().color = Color.red;

                //mira
                weaponBase.rotation = targetRotation;
                //atira
                GameObject bullet = Instantiate(sentinelBullet, targetMass.position, targetMass.rotation);
                bullet.layer = gameObject.layer;
                //INSTANCIAR EFEITOS AQUI
                //espera
                yield return new WaitForSeconds(bulletSpawnInterval);

            } else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsDifferentLayer(collision.gameObject.layer))
        {
            targetCharacters.Add(collision.gameObject.transform);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (IsDifferentLayer(collision.gameObject.layer))
        {
            targetCharacters.Remove(collision.gameObject.transform);
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

    private Vector3 targetDirection
    {
        get
        {
            Vector2 result = Vector2.zero;
            foreach (Transform t in targetCharacters)
            {
                if (Vector3.Distance(t.position, transform.position) > 0)
                {
                    result = t.position;
                }
            }
            return result;
        }
    }

    private Quaternion targetRotation
    {
        get
        {
            Vector2 direction = targetDirection - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }


 
}
