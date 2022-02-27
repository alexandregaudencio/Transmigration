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
    
    public event Action DamageEvent;


    public float HP { get => hp; set => hp = value; }
    private float maxHP;


    private float hpPercent => hp / maxHP;

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
    public void TakeDamage(int damage)
    {
        hp -= damage;
        DamageEvent?.Invoke();
        
        //if (hp <= 0) DeathEvent?.Invoke();
        if(hp <= 0) PV.RPC("SendDeathTransitionState", RpcTarget.All);
    }


    public void OnDamage()
    {
        lifeBarFill.fillAmount = hpPercent;
    }

    public void ResetHP()
    {
        hp = maxHP;
        lifeBarFill.fillAmount = hpPercent;

    }

    [PunRPC]
    public void SendDeathTransitionState()
    {
        sentinelStateController.TransitionToState(sentinelStateController.listedStates.deathStateSentinel);

    }




}
