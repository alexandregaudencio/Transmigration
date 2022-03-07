using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LoadingConnection : MonoBehaviourPunCallbacks
{
    private TMP_InputField inputfield_NickName;
    private string username;

    private void Awake()
    {
        inputfield_NickName = GetComponentInChildren<TMP_InputField>();
        //PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {

        inputfield_NickName.onValueChanged.AddListener(delegate
        {
            OnInputfieldValueChanged();
        });
    }


    public void OnClick_JoinLobby()
    {
        SetPlayerUsername();
        PhotonNetwork.ConnectUsingSettings();


    }


    private void SetPlayerUsername()
    {
        PhotonNetwork.AuthValues = new AuthenticationValues(username);
        PhotonNetwork.NickName = username;
        Debug.Log("Userid: "+PhotonNetwork.AuthValues.UserId);
    }


    private void OnInputfieldValueChanged()
    {
        username = inputfield_NickName.text;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("DISCONNECTED");
    }

    public override void OnConnected()
    {
        Debug.Log("CONNECTED");

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("CONNECTED to master");
        PhotonNetwork.JoinLobby();

    }


}
