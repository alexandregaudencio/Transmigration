using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageableSentinel : MonoBehaviour, IDamageable
{
    [SerializeField] private float hp;
    [SerializeField] private Image lifeBarFill;
    PhotonView PV;
    private SentinelStateController sentinelStateController;
    
    public event Action<float> DamageEvent;


    public float HP { get => hp; set => hp = value; }
    private float maxHP;


    private float hpFraction => hp / maxHP;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        sentinelStateController = GetComponentInChildren<SentinelStateController>();
    }

    private void Start()
    {
        maxHP = HP;
        //DeathEvent += OnDeath;
        DamageEvent += OnDamage;

    }

    private void OnDestroy()
    {
        //DeathEvent -= OnDeath;
        DamageEvent -= OnDamage;
    }



    [PunRPC]
    public void TakeDamage(float damage)
    {
        if(PV.IsMine)
        {
            hp -= damage;
            DamageEvent?.Invoke(damage);
            if (hp <= 0) PV.RPC("SendDeathTransitionState", RpcTarget.All);
        }

    }


    public void OnDamage(float damage = 0)
    {
        lifeBarFill.fillAmount = hpFraction;
    }

    public void ResetHP()
    {
        hp = maxHP;
        lifeBarFill.fillAmount = hpFraction;

    }

    [PunRPC]
    public void SendDeathTransitionState()
    {
        sentinelStateController.TransitionToState(sentinelStateController.listedStates.deathStateSentinel);

    }




}
