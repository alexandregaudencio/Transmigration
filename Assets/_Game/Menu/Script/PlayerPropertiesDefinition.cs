﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerPropertiesDefinition : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject[] charactersPrefab;

    //PhotonView PV;

    public static PlayerPropertiesDefinition instance;

    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();



    private void Start()
    {
        instance = this;
        //PV = GetComponent<PhotonView>();

    }


    void SetPlayerprops()
    {
        HashProperty["HP"] = GameConfigs.instance.HP;
        HashProperty["maxHP"] = GameConfigs.instance.HP;
        HashProperty["killCount"] = 0;
        HashProperty["deathCount"] = 0;
        HashProperty["timerRespawn"] = GameConfigs.instance.timeToRespawn ;
        HashProperty["isDead"] = false;
        PhotonNetwork.LocalPlayer.SetCustomProperties(HashProperty);
    }


    //[PunRPC]
    public void SetCharacterAndProps()
    {
        SetPlayerprops();

        int playerIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        PhotonNetwork.LocalPlayer.TagObject = charactersPrefab[0].name;
    }



}
