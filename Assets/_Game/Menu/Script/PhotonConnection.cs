
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject loadingCanvas;

    private void Awake()
    {
        loadingCanvas.SetActive(true);

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        if(!PhotonNetwork.IsConnected)
        {
            loadingCanvas.SetActive(false);
        }
        PhotonNetwork.ConnectUsingSettings();

    }

    void Update()
    {

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    public override void OnConnectedToMaster()
    {
        //Debug.Log("cONECTADO AO MASTER sERVER.");
        PhotonNetwork.JoinLobby();
        loadingCanvas.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("FOI DESCONECTADO. Devido a: " + cause);
        loadingCanvas.SetActive(true);
    }



}
