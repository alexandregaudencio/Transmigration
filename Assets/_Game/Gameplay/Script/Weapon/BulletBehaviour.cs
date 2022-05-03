using System.Collections;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private BulletProperty bulletProperty;
    private void Awake()
    {
        bulletProperty = GetComponent<BulletProperty>();
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right*bulletProperty.Speed, ForceMode2D.Impulse);
        StartCoroutine(WaitToDisable());
    }

    private void OnDisable()
    {
        StopCoroutine(WaitToDisable());
    }

    private IEnumerator WaitToDisable()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
