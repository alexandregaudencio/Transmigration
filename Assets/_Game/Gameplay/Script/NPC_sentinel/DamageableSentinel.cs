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
    Animator animator;
    [SerializeField] private AudioSource audioSource;
    public AudioClip deathClip;
    //[SerializeField] private ResetSentinel resetSentinel;
    
    public event Action DamageEvent;
    public event Action DeathEvent;

    public float HP { get => hp; set => hp = value; }
    private float maxHP;


    private float hpPercent => hp / maxHP;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        maxHP = HP;
        DeathEvent += Death;
        DamageEvent += OnDamage;

    }

    private void OnDestroy()
    {
        DeathEvent -= Death;
        DamageEvent -= OnDamage;
    }



    [PunRPC]
    public void TakeDamage(int damage)
    {
        hp -= damage;
        DamageEvent.Invoke();
        
        if (hp <= 0) DeathEvent.Invoke();
    }


    public void OnDamage()
    {
        lifeBarFill.fillAmount = hpPercent;
    }

    //[PunRPC]
    public void Death()
    {

        //GetComponent<SentinelStateController>().TransitionToState(GetComponent<SentinelStateController>().listedStates.deathStateSentinel);
        audioSource.clip = deathClip;
        audioSource.Play();
        hp = maxHP;
        //resetSentinel.ResetingSentinel();
        //gameObject.SetActive(false);

    }




}
