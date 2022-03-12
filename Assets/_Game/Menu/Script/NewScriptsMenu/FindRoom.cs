using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRoom : MonoBehaviourPunCallbacks
{
    
    private RoomOptions roomOptions
    {
        get
        {
            return new RoomOptions
            {
                MaxPlayers = (byte)GameConfigs.instance.MaxBattlePlayers,
                //PublishUserId = true,
                IsOpen = true,
                IsVisible =/* !toggleTeam.isOn*/ true
            };
        }
    }

    string randomRoom
    {
        get
        {
            return Random.Range(100, 999).ToString();
        }
    }
    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.JoinOrCreateRoom(randomRoom, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room: "+PhotonNetwork.CurrentRoom.Name);
    }
}
