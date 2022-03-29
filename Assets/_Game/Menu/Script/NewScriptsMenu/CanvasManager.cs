using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Realtime;

public enum ConnectionState
{
   DICONNECTED,
   IN_LOBBY,
   IN_ROOM,
}

public class CanvasManager : MonoBehaviourPunCallbacks
{
   [SerializeField]
    private List<MenuSate> menuState;


    private void Start()
    {
        SwitchCanvasActivity(ConnectionState.DICONNECTED);

    }

    public override void OnConnected()
    {
        Debug.Log("OnConnected");
        SwitchCanvasActivity(ConnectionState.DICONNECTED);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJOinedLobby");

        SwitchCanvasActivity(ConnectionState.IN_LOBBY);
       
    }


    
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");

        SwitchCanvasActivity(ConnectionState.IN_ROOM);
    }
    public override void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom");

        SwitchCanvasActivity(ConnectionState.IN_LOBBY);

    }


    private void SwitchCanvasActivity(ConnectionState actualState)
    {
        //Debug.Log(actualState);
        foreach(MenuSate menu in menuState)
        {
            menu.Canvastarget.SetActive(menu.State == actualState);   
        }
    }

}

[Serializable]
public class MenuSate
{
    [SerializeField]
    private ConnectionState state;
    [SerializeField]
    private GameObject canvastarget;

    public MenuSate(ConnectionState state, GameObject canvastarget)
    {
        this.State = state;
        this.Canvastarget = canvastarget;
    }

    public ConnectionState State { get => state; set => state = value; }
    public GameObject Canvastarget { get => canvastarget; set => canvastarget = value; }
}
