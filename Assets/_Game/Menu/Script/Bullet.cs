using UnityEngine;

namespace BulletNamespace
{
    [CreateAssetMenu(fileName ="Bullet", menuName = "new Bullet")]
    public class Bullet : ScriptableObject
    {
        [SerializeField] [Min(0)] private int damage;
        [SerializeField] [Min(0)] private float speed;
        [SerializeField] [Min(0)] private float manaCost;

        public float Speed { 
            get => speed * GameConfigs.instance.BulletSpeedScale; 
            set => speed = value; 
        }
        public float ManaCost { 
            get => manaCost; 
            set => manaCost = value; 
        }
        public int Damage { 
            get => damage; 
            set => damage = value; }
    }

}

