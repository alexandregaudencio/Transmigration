using Player.Data.Score;
using UnityEngine;
using UnityEngine.Events;

namespace DamageableNamespace
{
    public class TriggerDamage : MonoBehaviour
    {
        private BulletProperty bulletProperty;
        private PlayerScore playerScoreOrigin;
        public PlayerScore PlayerScoreOrigin { get => playerScoreOrigin; set => playerScoreOrigin = value; }
        public UnityEvent<float> onDamage;

        //[SerializeField] private 
        private void Awake()
        {
            bulletProperty = GetComponent<BulletProperty>();
        }

        private void OnEnable()
        {
            onDamage.AddListener(OnDamage);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.layer == gameObject.layer) return;

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if(damageable != null)
            {
                collision.gameObject.GetComponent<PlayerScoreManager>().LastPlayerDamager = PlayerScoreOrigin;
                damageable.TakeDamage(bulletProperty.Damage);
                onDamage?.Invoke(bulletProperty.Damage);

            }
        }

        private void OnDamage(float damage)
        {
            playerScoreOrigin.addDamageAmount(damage);

        }


    }

}






