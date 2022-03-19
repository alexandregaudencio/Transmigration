using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterDefineTeam : MonoBehaviourPunCallbacks
{
    public override void OnJoinedRoom()
    {
        VerifyTeamSlot();
    }

    //public override void OnEnable()
    //{
    //    PhotonTeamsManager.PlayerJoinedTeam += VerifyTeamSlot;
    //}

    //public override void OnDisable()
    //{
    //    PhotonTeamsManager.PlayerJoinedTeam -= VerifyTeamSlot;
    //}


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //if (PhotonNetwork.IsMasterClient)
        //    VerifyTeamSlot(newPlayer);
    }

    public void VerifyTeamSlot(/*Player player, PhotonTeam pt*/)
    {
        int teamCount = PhotonTeamsManager.Instance.GetTeamMembersCount(1);
        if (teamCount < GameConfigs.instance.MaxTeamPlayers)
        {
            PhotonNetwork.LocalPlayer.JoinTeam(1);
            return;
        }
        PhotonNetwork.LocalPlayer.JoinTeam(2);
    }

}


