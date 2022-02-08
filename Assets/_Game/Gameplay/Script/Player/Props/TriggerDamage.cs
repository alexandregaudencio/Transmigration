using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] [Min(0)] private int damage = 10;

    //public List<string> collisionTagsList;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer == this.gameObject.layer) return;
        
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(damage);
    }


}






