
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class StartupMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject CanvasLoading;

    private void Awake()
    {
        CanvasLoading.SetActive(true);

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        if(!PhotonNetwork.IsConnected)
        {
            CanvasLoading.SetActive(false);
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

    public override void OnDisconnected(DisconnectCause cause)
    {

        Debug.Log("FOI DESCONECTADO. Devido a: "+cause);
        CanvasLoading.SetActive(true);
        base.OnDisconnected(cause);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("cONECTADO AO MASTER sERVER.");
        CanvasLoading.SetActive(false);
        base.OnConnectedToMaster();
    }
}
