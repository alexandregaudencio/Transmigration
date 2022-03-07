using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Realtime;

public enum ConnectionState
{
   DICONNECTED,
   IN_LOBBY,
   IN_BATTLEROOM,
   //IN_BATTLEROOM
}

public class CanvasManager : MonoBehaviourPunCallbacks
{
   [SerializeField]
    private List<MenuSate> menuState;
    //public ConnectionState connectionState;


    private void Start()
    {
        SwitchCanvasActivity(ConnectionState.DICONNECTED);

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SwitchCanvasActivity(ConnectionState.DICONNECTED);
    }

    public override void OnJoinedLobby()
    {
        SwitchCanvasActivity(ConnectionState.IN_LOBBY);
       
    }
    //public override void OnLeftLobby()
    //{
    //    SwitchCanvasActivity(ConnectionState.DICONNECTED);

    //}

    public override void OnJoinedRoom()
    {
        //if (PhotonNetwork.CurrentRoom.MaxPlayers == GameConfigs.instance.maxTeamPlayers)
        //{
        //    SwitchCanvasActivity(ConnectionState.IN_TEAMROOM);
        //} 
        //else
        if (PhotonNetwork.CurrentRoom.MaxPlayers == GameConfigs.instance.MaxBattlePlayers)
        {
            SwitchCanvasActivity(ConnectionState.IN_BATTLEROOM);
        }
        else
        {
            Debug.Log("ROOM ERRO!");
        }

    }



    private void SwitchCanvasActivity(ConnectionState actualState)
    {
        Debug.Log(actualState);
        foreach(MenuSate menu in menuState)
        {
            menu.Canvastarget?.SetActive(menu.State == actualState);   
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
