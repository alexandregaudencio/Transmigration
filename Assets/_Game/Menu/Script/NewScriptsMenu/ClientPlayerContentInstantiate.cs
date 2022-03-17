using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientPlayerContentInstantiate : MonoBehaviourPunCallbacks
{



    //public void VerifyPlayerListingSlot(Player player)
    //{
    //    if (PhotonTeamsManager.GetTeamMembersCount(photonTeams[0].Code) <= GameConfigs.instance.maxTeamPlayers)
    //    {
    //        InitializePlayer(player, photonTeams[0].Name, playerListings[0].transform);
    //        return;
    //    }
    //    InitializePlayer(player, photonTeams[1].Name, playerListings[1].transform);

    //}

    //private void InitializePlayer(Player player, string teamName, Transform targetTransform)
    //{
    //    GameObject intantiateContent = Instantiate(playerContent,
    //        targetTransform.position,
    //        targetTransform.rotation);
    //    intantiateContent.transform.SetParent(targetTransform.transform);
    //    intantiateContent.transform.localScale = new Vector3(1, 1, 1);
    //    intantiateContent.GetComponent<PlayerTeam>().Initialize(player, teamName);
    //}


}
