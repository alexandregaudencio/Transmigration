using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleButtonManager : MonoBehaviourPunCallbacks
{
    //[SerializeField] private GameObject button_Start;

    ////private void Start()
    ////{
    ////    button_Start.SetActive(false);
    ////}

    //public override void OnEnable()
    //{
    //    ShowButtonStartIfRoomIsFull();

    //}

    ////N�O FUNCIONA
    //public override void OnPlayerEnteredRoom(Player newPlayer)
    //{
    //    ShowButtonStartIfRoomIsFull();
    //}


    ////N�O FUNCIONA
    //public override void OnPlayerLeftRoom(Player otherPlayer)
    //{
    //    ShowButtonStartIfRoomIsFull();
    //}


    ////mostra o bot�o START GAME para o masterClient

    //public void ShowButtonStartIfRoomIsFull()
    //{
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        //TODO: Trocar por uma lista local de players, como no v�deo 
    //        byte playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
    //        byte maxPlayers = PhotonNetwork.CurrentRoom.MaxPlayers;
    //        button_Start.SetActive((playerCount == maxPlayers) ? true : false);
    //    }

    //}



}
