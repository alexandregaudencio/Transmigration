using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamPlayersCountToText : MonoBehaviourPunCallbacks
{
    private Text text_teamPlayersCount;

    private void Awake()
    {
        text_teamPlayersCount = GetComponent<Text>();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        text_teamPlayersCount.text = "...";
    }


    public override void OnJoinedRoom()
    {
        UpdateTeamPlayersCountText();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdateTeamPlayersCountText();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateTeamPlayersCountText();
    }

    private void UpdateTeamPlayersCountText()
    {
        text_teamPlayersCount.text = PhotonNetwork.CurrentRoom.PlayerCount + " of " + PhotonNetwork.CurrentRoom.MaxPlayers;
    }


}
