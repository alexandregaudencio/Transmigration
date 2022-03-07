using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateRoomManager : MonoBehaviourPunCallbacks
{
    private TMP_InputField inputFieldCreateTeam;
    private Toggle toggleTeam;

    private RoomOptions roomOptions
    {
        get
        {
            return new RoomOptions
            {
                MaxPlayers = (byte)GameConfigs.instance.maxTeamPlayers,
                PublishUserId = true,
                IsOpen = true,
                IsVisible = !toggleTeam.isOn
            };
        }
    }


    string randomTeamName
    {
        get
        {
            return Random.Range(100, 999).ToString();
        }
    }

    private string teamName
    {
        get
        {
            return inputFieldCreateTeam.text;
        }
    }




    private void Awake()
    {
        inputFieldCreateTeam = GetComponentInChildren<TMP_InputField>();
        toggleTeam = GetComponentInChildren<Toggle>();
    }


    public void OnClick_CreateRoom()
    {
        if(inputFieldCreateTeam.text == "")
        {
            PhotonNetwork.CreateRoom(randomTeamName, this.roomOptions);
        } else
        {
            PhotonNetwork.JoinOrCreateRoom(teamName, this.roomOptions, TypedLobby.Default);
        }
    }



    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        PhotonNetwork.CreateRoom(randomTeamName, this.roomOptions);
    }





}
