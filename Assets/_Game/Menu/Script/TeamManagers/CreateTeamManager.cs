using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateTeamManager : MonoBehaviourPunCallbacks
{
    private TMP_InputField inputFieldCreateTeam;
    private Toggle toggleTeam;

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

    private RoomOptions roomOptions
    {
        get
        {
            return new RoomOptions
            {
                MaxPlayers = (byte)GameConfigs.instance.maxRoomPlayers,
                IsOpen = true,
                IsVisible = !toggleTeam.isOn
            };
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
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("CAMPO VAZIO. ENTRADA AUTOMÁTIA EM UMA SALA.");
        } else
        {
            PhotonNetwork.JoinOrCreateRoom(teamName, this.roomOptions, TypedLobby.Default);
            Debug.Log("sala criada: " + teamName);
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {

        ///TODO: Mensagem de falha;
        ///

        //PhotonNetwork.CreateRoom(randomTeamName, this.roomOptions);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        PhotonNetwork.CreateRoom(randomTeamName, this.roomOptions);
        Debug.Log("sala criada: " + randomTeamName);
    }

}
