﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGame : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private PlayerPropertiesDefinition playerPropertiesDefinition;

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        /*GetComponentInChildren<ge>().gameObject.SetActive*/
        if(PhotonNetwork.IsMasterClient)
        {
            byte playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            byte maxPlayers = PhotonNetwork.CurrentRoom.MaxPlayers;
            startButton.SetActive(( playerCount == maxPlayers ) ? true : false);

        } 
    }


    //quando o btão de start game é apertado
    public void StartMatchmaking()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        StartCoroutine(waitToStart());
    }

    IEnumerator waitToStart()
    {
        GetComponent<PhotonView>().RPC("SetProps", RpcTarget.All);

        yield return new WaitForSeconds(1);
        PhotonNetwork.LoadLevel(GameConfigs.instance.gameplaySceneIndex);

    }

    [PunRPC]
    public void SetProps()
    {
        playerPropertiesDefinition.SetCharacterAndProps();

    }
}
