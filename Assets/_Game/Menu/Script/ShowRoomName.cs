using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRoomName : MonoBehaviourPunCallbacks
{
    //[SerializeField] private LobbyController lobbyController;


    //public void RoomNameToText()
    //{
    //    GetComponent<Text>().text = PhotonNetwork.CurrentRoom.Name;
    //}

    //public override void OnJoinRandomFailed(short returnCode, string message)
    //{
    //    string roomName = Random.Range(0, 2000).ToString();
    //    RoomOptions roomOptions = new RoomOptions()
    //    {
    //        MaxPlayers = (byte)GameConfigs.instance.maxRoomPlayers,
    //        IsOpen = true
    //    };
    //    PhotonNetwork.CreateRoom(roomName, roomOptions);
    //}

    public override void OnJoinedRoom()
    {
        GetComponent<Text>().text = PhotonNetwork.CurrentRoom.Name;
    }
        //public override void onjoinedroom()
        //{
        //    getcomponent<text>().text = photonnetwork.currentroom.name;
        //}
    }
