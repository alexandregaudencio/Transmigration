using BulletNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperty : MonoBehaviour
{
    [SerializeField] private Bullet bullet;

    private float manaCost;
    private float speed;
    private float damage;
    private GameObject bulletPrefab;

    public float ManaCost { get => manaCost;}
    public float Speed { get => speed;}
    public float Damage { get => damage;}
    public GameObject BulletPrefab { get => bulletPrefab;}

    private void Start()
    {
        manaCost = bullet.ManaCost;
        speed = bullet.Speed;
        damage = bullet.Damage;
        bulletPrefab = bullet.BulletPrefab;
    }
}
