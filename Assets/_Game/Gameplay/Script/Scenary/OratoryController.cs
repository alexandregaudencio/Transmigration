using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OratoryController : MonoBehaviour
{
    PhotonView PV;
    [SerializeField] private GameObject textObject;
   /* [SerializeField] */private ParticleSystem particle;
    [SerializeField] private KeyCode key;
    
    [SerializeField] private float emissionRate = 20;
    ParticleSystem.EmissionModule emissionModule;

    [SerializeField] private float maxMeditating;
    public float meditatingCount;

    private bool canMeditate = false;

    public float meditatePercent => meditatingCount / maxMeditating;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        PV = GetComponent<PhotonView>();
        emissionModule = particle.emission;
        emissionModule.rateOverTime = 0;

    }

    private void FixedUpdate()
    {
        if (canMeditate) Meditate();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ajustar o collisionTeam
        int Layer = collision.gameObject.layer;
        if (collision.gameObject.CompareTag("character") && Layer == LayerMask.NameToLayer("TeamB"))
        {

            OnMeditation(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int Layer = collision.gameObject.layer;
        if (collision.gameObject.CompareTag("character") && Layer == LayerMask.NameToLayer("TeamB"))
        {

            OnMeditation(false);
        }
    }

    public void OnMeditation(bool value)
    {
        canMeditate = value;
        textObject.SetActive(value);


    }


    public void Meditate()
    {

        if (Input.GetKey(key) && PV.Controller == PhotonNetwork.LocalPlayer  )
        {
            //PhotonNetwork.LocalPlayer.GetPhotonTeam().Name == "TeamB";
            PV.RPC("OnMeditate", RpcTarget.All, true);
            meditatingCount += Time.fixedDeltaTime;
        } else
        {
            PV.RPC("OnMeditate", RpcTarget.All, false);
        }

        if(meditatingCount >= maxMeditating)
        {
            //PONTUAÇÃO
            PV.RPC("MeditationCompleted", RpcTarget.All);
        }
        
    }

    //public void MeditateEvent(bool isMaditating)
    //{
    //    emissionModule.rateOverTime = isMaditating ? emissionRate : 0;

    //}


    [PunRPC]
    public void OnMeditate(bool isMeditating)
    {
        emissionModule.rateOverTime = isMeditating ? emissionRate : 0;

    }

    [PunRPC]
    public void MeditationCompleted()
    {
        this.gameObject.SetActive(false);

    }



}
