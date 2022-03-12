using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LoadingConnection : MonoBehaviourPunCallbacks
{
    private string username;

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
    private new void OnDisable()
    {
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //PhotonNetwork.JoinLobby();
        Debug.Log("PQ DISCONNECTED");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("joined_Looby");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("CONNECTED to master");
        PhotonNetwork.JoinLobby();

    }


    //private IEnumerator ConnectionCoroutine()
    //{
    //    if (!PhotonNetwork.IsConnected) PhotonNetwork.ConnectUsingSettings();
    //    yield return new WaitForSeconds(0.5f);
    //}


}
