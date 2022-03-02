using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ConnectionState
{
   DICONNECTED,
   IN_LOBBY,
   IN_TEAMROOM,
   IN_BATTLEROOM
}

public class CanvasManager : MonoBehaviourPunCallbacks
{
    public List<MenuSate> menuState;
    //public ConnectionState connectionState;


    private void Start()
    {
        SwitchCanvasActivity(ConnectionState.DICONNECTED);

    }

    public override void OnJoinedLobby()
    {
        SwitchCanvasActivity(ConnectionState.IN_LOBBY);
       
    }

    public override void OnJoinedRoom()
    {
        SwitchCanvasActivity(ConnectionState.IN_TEAMROOM);

    }

    private void SwitchCanvasActivity(ConnectionState actualState)
    {
        foreach(MenuSate menu in menuState)
        {
            menu.canvastarget.SetActive(menu.state == actualState);
            
        }
    }


}

[Serializable]
public class MenuSate
{
    public ConnectionState state;
    public GameObject canvastarget;

    public MenuSate(ConnectionState state, GameObject canvastarget)
    {
        this.state = state;
        this.canvastarget = canvastarget;
    }
}
