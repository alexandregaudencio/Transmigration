using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleRoomManager :  MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text text_roomCount;
    [SerializeField] private GameObject button_startBattle;

    private  new void OnEnable()
    {
        text_roomCount.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " + GameConfigs.instance.MaxBattlePlayers;
        button_startBattle.SetActive(false);
    }

    private new void OnDisable()
    {
        text_roomCount.text = "...";

    }

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Update()
    {
        text_roomCount.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " + GameConfigs.instance.MaxBattlePlayers;
        bool isRoomFull = (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers);
        if (PhotonNetwork.IsMasterClient)
        {
            button_startBattle.SetActive(isRoomFull);
        }

    }

    public override void OnJoinedRoom()
    {
        text_roomCount.text = PhotonNetwork.CurrentRoom.PlayerCount + " / " + GameConfigs.instance.MaxBattlePlayers;
        
        bool isRoomFull = (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers);
        button_startBattle.SetActive(isRoomFull);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Alguem entrou na sala!");

    }


    public void OnClick_StartBattle()
    {
        PhotonNetwork.LoadLevel(GameConfigs.instance.gameplaySceneIndex);
    }
}
