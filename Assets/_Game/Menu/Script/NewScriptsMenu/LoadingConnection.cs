using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LoadingConnection : MonoBehaviourPunCallbacks
{

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    private new void OnEnable()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.ConnectUsingSettings();
    }


}
