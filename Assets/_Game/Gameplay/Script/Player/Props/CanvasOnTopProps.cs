﻿using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOnTopProps : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text nickText;
    [SerializeField] private Image fillLifeBarImage;
    string team => PV.Controller.GetPhotonTeam().Name;

    PhotonView PV;


    public Color GetColor => (team == "Blue") ? 
        GameConfigs.instance.TeamBColor1 : GameConfigs.instance.TeamAColor1;


    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    public float HPpercentage
    {
        get
        {
            int hp = (int)PV.Controller.CustomProperties["HP"];
            int maxHP = (int)PV.Controller.CustomProperties["maxHP"];
            return (float)hp / maxHP;
        }
    }


    private void Start()
    {
        nickText.text = PV.Controller.NickName;
        fillLifeBarImage.color = GetColor;
        fillLifeBarImage.fillAmount = HPpercentage;

    }



    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (PV.Controller == targetPlayer && changedProps.ContainsKey("HP"))
        {
            fillLifeBarImage.fillAmount = HPpercentage;
        }
    }

}

