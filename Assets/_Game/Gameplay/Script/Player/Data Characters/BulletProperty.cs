using BulletNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperty : MonoBehaviour
{
    [SerializeField] private Bullet bullet;

    public float ManaCost { get => bullet.ManaCost;}
    public float Speed { get => bullet.Speed;}
    public float Damage { get => bullet.Damage;}
    public GameObject BulletPrefab { get => bullet.BulletPrefab;}

}
