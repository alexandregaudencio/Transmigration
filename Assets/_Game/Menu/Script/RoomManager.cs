﻿using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Collections;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TeamManager teamManager;
    [SerializeField] private Text playerCountText;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Start()
    {
        GetComponent<AudioSource>().Play();
    }



    //AÇÃO BOTÃO Join Team
    public void JoinTeam()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    ////AÇÃO BOTAO LeftTeam
    //public void LeftTeam()
    //{
    //    PhotonNetwork.LeaveRoom();
    //}

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string roomName = "#"+Random.Range(100, 999).ToString();
        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = (byte)GameConfigs.instance.maxRoomPlayers,
            IsOpen = true
        };
        PhotonNetwork.CreateRoom(roomName, roomOptions);
        Debug.Log("criei a sala: " + roomName);
    }


    //QUANDO O LOCAL ENTRA NA SALA
    public override void OnJoinedRoom()
    {
        
        //define seu time quando entra na sala
        teamManager.SetTeam(PhotonNetwork.LocalPlayer);
        //GetComponent<PlayerPropertiesDefinition>().SetCharacter();
        Debug.Log("Entrei na sala: "+PhotonNetwork.CurrentRoom.Name);

        UpdatePlayercountText();


    }

    //QUANDO ALGUÉM ENTRA NA SALA
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {


        UpdatePlayercountText();


    }

    //AÇÃO BOTÃO START



    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayercountText();
    }




    private void UpdatePlayercountText()
    {
        playerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount + " de " + PhotonNetwork.CurrentRoom.MaxPlayers;
    }



}
