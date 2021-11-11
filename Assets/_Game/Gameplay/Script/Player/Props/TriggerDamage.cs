using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] [Min(0)] private int damage = 10;

    public List<string> collisionTagsList;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.layer == collision.gameObject.layer) return;

        if (collisionTagsList.Contains(collision.gameObject.tag))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
        }
    }



}






