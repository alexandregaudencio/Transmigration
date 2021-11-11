using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageableSentinel : MonoBehaviour, IDamageable
{
    [SerializeField] private float hp;
    [SerializeField] private Image lifeBarFill;
    PhotonView PV;
    Animator animator;

    public float HP { get => hp; set => hp = value; }
    private float maxHP;
    bool isDead = false;

    private float hpPercent => hp / maxHP;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        
    }

    private void Start()
    {
        maxHP = HP;
    }



    [PunRPC]
    public void TakeDamage(int damage)
    {
        hp -= damage;
        lifeBarFill.fillAmount = hpPercent;
        
        CheckDeath();
    }

    private void CheckDeath()
    {
        if(hp <= 0)
        {
           //PV.RPC("DeathEvent", RpcTarget.All );
            DeathEvent();
        }
    }

    [PunRPC]
    public void DeathEvent()
    {
        isDead = true;
        gameObject.SetActive(false);
    }



}
