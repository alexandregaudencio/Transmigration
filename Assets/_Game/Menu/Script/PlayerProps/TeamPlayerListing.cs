using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeamPlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerContent;
    [SerializeField] public PhotonTeamsManager photonTeamsManager;
    [SerializeField] private TeamName teamTarget;
    
    private Player[] players;
    public List<Player> playersListing => players.ToList();
    private new void OnEnable()
    {
        PhotonTeamsManager.PlayerJoinedTeam += VerifyTeamToInstantiate;
        //InitalizeAllPlayersContent();
    }


    private new void OnDisable()
    {
        PhotonTeamsManager.PlayerJoinedTeam -= VerifyTeamToInstantiate;

    }

    public void VerifyTeamToInstantiate(Player player, PhotonTeam photonTeam)
    {
        //newPlayer Add
        


        //Local e first
        if (player == PhotonNetwork.LocalPlayer)
            InitalizeAllPlayersContent();
         else
            if (photonTeam.Name == teamTarget.ToString() && !playersListing.Contains(player))
                InstantiateContent(player);
        

    }

    private void InitalizeAllPlayersContent()
    {
        Debug.Log("Initializing players content");
        //Array.Clear(players, 0, players.Length);
        if (photonTeamsManager.TryGetTeamMembers(teamTarget.ToString(), out players))
            Debug.Log("Deu bom ");
        else
            Debug.Log("Deu ruim.");
        
        foreach (Player player in players)
        {
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
}
