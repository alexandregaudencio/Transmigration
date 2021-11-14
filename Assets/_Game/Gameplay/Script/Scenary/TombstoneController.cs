using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TombstoneController : MonoBehaviour
{
    PhotonView PV;
    [SerializeField] private GameObject textObject;
   /* [SerializeField] */private ParticleSystem particle;
    [SerializeField] private KeyCode key;
    [SerializeField] private string targetTeam;
    [SerializeField] private float emissionRate = 20;
    ParticleSystem.EmissionModule emissionModule;

    [SerializeField] private float maxMeditating;
    public float meditatingCount;

    private bool canMeditate = false;
    [SerializeField] private bool RedTombstone;
    [SerializeField] private AudioSource audioSource;
    public AudioClip playDoneClip;

    [SerializeField] private ResetTombstone resetTombstone;


    [SerializeField] private Image meditateBar; 


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
        if (/*!IsDifferentLayer(collision.gameObject.layer) && */collision.gameObject.CompareTag("character"))
        {
            
            Debug.Log("On Meditation.");
            OnMeditationZone(true);

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(/*!IsDifferentLayer(collision.gameObject.layer) &&*/ collision.gameObject.CompareTag("character")) 
        {
            Debug.Log("Out Meditation.");
            OnMeditationZone(false);
        }

    }

    public void OnMeditationZone(bool value)
    {
        canMeditate = value;
        textObject.SetActive(value);
        updateUImeditate();


    }

    void updateUImeditate()
    {
        meditateBar.fillAmount = meditatePercent;
    }

    public void Meditate()
    {
        //if (PV.IsMine == RedTombstone)
        //{
            if (Input.GetKey(GameConfigs.instance.MeditateKey) )
            {
                PV.RPC("UpdateMeditateCount", RpcTarget.All);
            }


            if (Input.GetKeyDown(GameConfigs.instance.MeditateKey))
            {

                //PhotonNetwork.LocalPlayer.GetPhotonTeam().Name == "TeamB";
                PV.RPC("OnMeditate", RpcTarget.All, emissionRate);
                //OnMeditate(emissionRate);

            }

            if(Input.GetKeyUp(GameConfigs.instance.MeditateKey))
            {
                PV.RPC("OnMeditate", RpcTarget.All, 0f);
            //OnMeditate(0);
            }



        //}


        if (meditatingCount >= maxMeditating)
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
    public void OnMeditate(float isMeditating)
    {
        emissionModule.rateOverTime = isMeditating;

    }

    [PunRPC]
    public void UpdateMeditateCount()
    {
        meditatingCount += Time.fixedDeltaTime;

    }

    [PunRPC]
    public void MeditationCompleted()
    {

        audioSource.clip = playDoneClip;
        audioSource.Play();
        resetTombstone.ResetingTombstone();
        this.gameObject.SetActive(false);


    }



    private bool IsDifferentLayer(LayerMask layer)
    {

        if (this.gameObject.layer == LayerMask.NameToLayer("TeamA") && layer.value == LayerMask.NameToLayer("TeamB"))
        {
            return true;
        }
        else if (this.gameObject.layer == LayerMask.NameToLayer("TeamB") && layer.value == LayerMask.NameToLayer("TeamA"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
