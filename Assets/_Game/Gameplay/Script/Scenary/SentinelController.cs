using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelController : MonoBehaviour
{
    [SerializeField] [Range(0,5)] private float bulletSpawnInterval;
    [SerializeField] private GameObject sentinelBullet;
    [SerializeField] private Transform targetMass;
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private float VisionRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Roration();


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, VisionRange);
    }

    private void Roration()
    {
        Vector2 direction = targetPlayer.position - targetMass.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

}
