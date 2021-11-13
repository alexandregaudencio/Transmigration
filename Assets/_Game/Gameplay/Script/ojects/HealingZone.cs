using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class HealingZone : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    [SerializeField] private int healingAmount;
    [SerializeField] [Min(0)] private float healingRateInSeconds;
    [SerializeField]  private LayerMask layerTarget;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        if (collision.gameObject.CompareTag("character") /*&& layer == layerTarget.value*/)
        {
            StartCoroutine(Healing(collision.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        if (collision.gameObject.CompareTag("character") /*&& layer == layerTarget.value*/)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //int layer = collision.gameObject.layer;
        if (collision.gameObject.CompareTag("character") /*&& collision.gameObject.layer == layerTarget.value*/)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }


    private IEnumerator Healing(GameObject target)
    {
        //PlayerProperty targetProperty = target.GetComponent<PlayerProperty>();
        target.GetComponent<PlayerProperty>()?.IncreaseHP(healingAmount);
        //targetProperty?.IncreaseHP(healingAmount);

        yield return new WaitForSeconds(healingRateInSeconds);


    }

}
