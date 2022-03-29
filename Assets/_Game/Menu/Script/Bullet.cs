using UnityEngine;

namespace BulletNamespace
{
    [CreateAssetMenu(fileName ="Bullet", menuName = "new Bullet")]
    public class Bullet : ScriptableObject
    {
        [SerializeField] [Min(0)] private float damage;
        [SerializeField] [Min(0)] private float speed;
        [SerializeField] [Min(0)] private float manaCost;
        [SerializeField] private GameObject bulletPrefab;
        public float Speed { 
            get => speed; 
            set => speed = value; 
        }
        public float ManaCost { 
            get => manaCost; 
            set => manaCost = value; 
        }
        public float Damage { 
            get => damage; 
            set => damage = value; }
        public GameObject BulletPrefab { get => bulletPrefab; set => bulletPrefab = value; }
    }

}

