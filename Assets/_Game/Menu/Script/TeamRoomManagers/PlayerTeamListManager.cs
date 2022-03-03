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
        text_PlayerTeamList = GetComponent<TMP_Text>();

    }

    private void Start()
    {
        text_PlayerTeamList.text = "";
    }

    private void OnEnable()
    {
        UpdatePlayerList();
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

    public void UpdatePlayerList()
    {
        text_PlayerTeamList.text = "";
        foreach (KeyValuePair<int,Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            text_PlayerTeamList.text += player.Value.NickName + "\n";
        }

        //text_PlayerTeamList.text += player.NickName + "\n";

    }

    public override void OnLeftRoom()
    {
        text_PlayerTeamList.text = "";
    }

}
