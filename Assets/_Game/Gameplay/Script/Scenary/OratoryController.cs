using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OratoryController : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    PhotonView PV;
    [SerializeField] private GameObject textObject;
   /* [SerializeField] */private ParticleSystem particle;
    [SerializeField] private KeyCode key;
    
    [SerializeField] private float emissionRate = 20;
    ParticleSystem.EmissionModule emissionModule;

    [SerializeField] private float maxOracao;
    public float OracaoCount;

    private bool canOrar = false;

    public float oracaoPercent => OracaoCount / maxOracao;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        PV = GetComponent<PhotonView>();
        emissionModule = particle.emission;
        emissionModule.rateOverTime = 0;

    }

    private void FixedUpdate()
    {
        if (canOrar) Orar();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string CollisionTeam = collision.gameObject.GetComponent<PlayerProperty>().Team;
        if (collision.gameObject.CompareTag("Player") && CollisionTeam == "Blue")
        {
            
            OnOratory(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string CollisionTeam = collision.gameObject.GetComponent<PlayerProperty>().Team;
        if (collision.gameObject.CompareTag("Player") && CollisionTeam == "Blue")
        {

            OnOratory(false);
        }
    }

    public void OnOratory(bool value)
    {
        canOrar = value;
        textObject.SetActive(value);


    }



    public void Orar()
    {
        if (Input.GetKey(key))
        {
            PV.RPC("MeditateEvent", RpcTarget.All, true);
            OracaoCount += Time.fixedDeltaTime;
        } else
        {
            PV.RPC("MeditateEvent", RpcTarget.All, false);
        }

        if(OracaoCount >= maxOracao)
        {
            //PONTUAÇÃO
            PV.RPC("BreakOracao", RpcTarget.All);
        }
        
    }

    [PunRPC]
    public void MeditateEvent(bool isMaditating)
    {
        emissionModule.rateOverTime = isMaditating ? emissionRate : 0;

    }


    [PunRPC]
    public void BreakOracao()
    {
        this.gameObject.SetActive(false);

    }


}
