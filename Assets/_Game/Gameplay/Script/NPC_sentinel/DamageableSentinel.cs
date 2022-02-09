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
    [SerializeField] private AudioSource audioSource;
    public AudioClip deathClip;
    [SerializeField] private ResetSentinel resetSentinel;

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

    //[PunRPC]
    public void DeathEvent()
    {
        audioSource.clip = deathClip;
        audioSource.Play();
        hp = maxHP;
        resetSentinel.ResetingSentinel();
        gameObject.SetActive(false);

    }



}
