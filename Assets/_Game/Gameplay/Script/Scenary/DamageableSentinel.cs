using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableSentinel : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp;

    PhotonView PV;
    public int Hp { get => hp; set => hp = value; }

    bool isDead = false;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    [PunRPC]
    public void TakeDamage(int damage)
    {
        hp -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if(hp <= 0)
        {
            isDead = true;
        }
    }
}
