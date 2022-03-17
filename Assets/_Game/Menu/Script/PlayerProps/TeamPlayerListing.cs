using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerContent;
    [SerializeField] public PhotonTeamsManager photonTeamsManager;
    [SerializeField] private TeamName teamTarget;
    
    private Player[] players;

    //public override void OnJoinedRoom()
    //{
    //    PhotonTeamsManager.Instance.TryGetTeamMembers(teamTarget.ToString(), out players);
    //    InitalizeAllPlayers();

    //}


    private new void OnEnable()
    {
        PhotonTeamsManager.PlayerJoinedTeam += VerifyTeamToInstantiate;

    }


    private new void OnDisable()
    {
        PhotonTeamsManager.PlayerJoinedTeam -= VerifyTeamToInstantiate;

    }

    public void VerifyTeamToInstantiate(Player player, PhotonTeam photonTeam)
    {
        if (photonTeam.Name == teamTarget.ToString() && players != null)
            InstantiateContent(player);

        if (player == PhotonNetwork.LocalPlayer && players == null)
        {
            photonTeamsManager.TryGetTeamMembers(teamTarget.ToString(), out players);
            InitalizeAllPlayersContent();
        }

    }

    private void InitalizeAllPlayersContent()
    {
        Debug.Log("Chamaei no INITIALIZEALLPLAYERS");
        Debug.Log("count: " + players.Length); //0
        photonTeamsManager.TryGetTeamMembers(teamTarget.ToString(), out players);
        
        foreach(Player player in players)
        {
            Debug.Log(player.NickName);
            InstantiateContent(player);
        }
    }

    private void InstantiateContent(Player player)
    {
        GameObject instantiateContent = Instantiate(playerContent, transform.position, transform.rotation);
        instantiateContent.transform.SetParent(transform);
        instantiateContent.transform.localScale = new Vector3(1, 1, 1);
        instantiateContent.GetComponent<PlayerTeam>().InitializeContent(player/*, teamName*/);
    }

    
    //private void DestoyChilds()
    //{
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        Debug.Log("Destroi child: " + i);
    //        Destroy(transform.GetChild(i).gameObject);
    //    }
    //}


}
