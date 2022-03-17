using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Realtime;

public enum ConnectionState
{
   //DICONNECTED,
   IN_LOBBY,
   IN_ROOM,
}

public class CanvasManager : MonoBehaviourPunCallbacks
{
   [SerializeField]
    private List<MenuSate> menuState;


    private void Start()
    {
        SwitchCanvasActivity(ConnectionState.IN_LOBBY);

    }

    //public override void OnDisconnected(DisconnectCause cause)
    //{
    //    SwitchCanvasActivity(ConnectionState.IN_LOBBY);
    //}

    public override void OnJoinedLobby()
    {
        SwitchCanvasActivity(ConnectionState.IN_LOBBY);
       
    }

    
    public override void OnJoinedRoom()
    {  
        SwitchCanvasActivity(ConnectionState.IN_ROOM);
    }
    public override void OnLeftRoom()
    {
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
