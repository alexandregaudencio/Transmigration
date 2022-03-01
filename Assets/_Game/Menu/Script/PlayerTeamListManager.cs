using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTeamListManager : MonoBehaviourPunCallbacks
{
    private TMP_Text text_PlayerTeamList;


    private void Awake()
    {
        text_PlayerTeamList = GetComponentInChildren<TMP_Text>();

    }

    private void Start()
    {
        text_PlayerTeamList.text = "";
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnJoinedRoom()
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    private void UpdatePlayerList()
    {
        text_PlayerTeamList.text = "";
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            text_PlayerTeamList.text += player.NickName + "\n";
        }

    }

}
