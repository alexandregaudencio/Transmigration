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
        [SerializeField] private Image image_hpFill;
        private PhotonView PV;
        [SerializeField] private HPManager hpManager;

        private void Awake()
        {
            PV = GetComponentInParent<PhotonView>();
             
        }

        private void Start()
        {
            image_hpFill.fillAmount = hpManager. HPfraction;
        }


        public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        {
            if (PV.Controller == targetPlayer && changedProps.ContainsKey("HP"))
            {
                image_hpFill.fillAmount = hpManager.HPfraction;
            }
        }


    }
}

