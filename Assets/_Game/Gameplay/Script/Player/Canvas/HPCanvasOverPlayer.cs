using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasOverPlayerNamespace
{

    public class HPCanvasOverPlayer : MonoBehaviourPunCallbacks
    {
        private Image image_hpFill;
        private PhotonView PV;
        public float HPfraction
        {
            get
            {
                int hp = (int)PV.Controller.CustomProperties["HP"];
                int maxHP = (int)PV.Controller.CustomProperties["maxHP"];
                return (float)hp / maxHP;
            }
        }


        private void Awake()
        {
            PV = GetComponentInParent<PhotonView>();
             
        }

        private void Start()
        {
            image_hpFill.fillAmount = HPfraction;

        }


        public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        {
            if (PV.Controller == targetPlayer && changedProps.ContainsKey("HP"))
            {
                image_hpFill.fillAmount = HPfraction;
            }
        }


    }
}

