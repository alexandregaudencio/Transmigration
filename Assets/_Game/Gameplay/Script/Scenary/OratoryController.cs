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
    [SerializeField] private string targetTeam;
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
        if (!IsDifferentLayer(collision.gameObject.layer) && collision.gameObject.CompareTag("character"))
        {
            Debug.Log("On Meditation.");
            OnMeditation(true);

        }

        ////ajustar o collisionTeam
        //string colTeam = collision.gameObject.GetComponent<PlayerProperty>().Team;
        //Debug.Log(colTeam + "ANOTHER TEAM: " + targetTeam);

        //if (collision.gameObject.CompareTag("character") && colTeam == targetTeam)
        //{

        //    OnMeditation(true);
        //}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(!IsDifferentLayer(collision.gameObject.layer) && collision.gameObject.CompareTag("character")) 
        {
            Debug.Log("Out Meditation.");
            OnMeditation(false);
        }
        //string colTeam = collision.gameObject.GetComponent<PlayerProperty>().Team;
        //Debug.Log(colTeam + "ANOTHER TEAM " + targetTeam);

        //if (collision.gameObject.CompareTag("character") && colTeam == targetTeam)
        //{

        //    OnMeditation(false);
        //}
    }

    public void OnMeditation(bool value)
    {
        canMeditate = value;
        textObject.SetActive(value);


    }


    public void Meditate()
    {
        if(PV.Controller == PhotonNetwork.LocalPlayer)
        {
            if (Input.GetKeyDown(GameConfigs.instance.MeditateKey))
            {
                //PhotonNetwork.LocalPlayer.GetPhotonTeam().Name == "TeamB";
                PV.RPC("OnMeditate", RpcTarget.All, emissionRate);
                OnMeditate(emissionRate);
                meditatingCount += Time.fixedDeltaTime;

            }

           if(Input.GetKeyUp(GameConfigs.instance.MeditateKey))
            {
                PV.RPC("OnMeditate", RpcTarget.All, 0);
                OnMeditate(0);
            }



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
    public void OnMeditate(float isMeditating)
    {
        emissionModule.rateOverTime = isMeditating;

    }

    [PunRPC]
    public void MeditationCompleted()
    {
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
