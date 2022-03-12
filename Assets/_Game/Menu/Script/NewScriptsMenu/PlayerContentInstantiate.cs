using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContentInstantiate : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform[] playerListings;
    [SerializeField] private GameObject playerContent;
    [SerializeField] private PhotonTeamsManager photonTeamsManager;

    PhotonTeam[] photonTeams => photonTeamsManager.GetAvailableTeams();

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnEnable()
    {

        if (photonTeamsManager.GetTeamMembersCount(photonTeams[0].Code) <= GameConfigs.instance.maxTeamPlayers)
        {
            InitializePlayer(photonTeams[0].Name, playerListings[0].transform);
        } else
        {
            InitializePlayer(photonTeams[1].Name, playerListings[1].transform);

        }

        //if (PhotonNetwork.CurrentRoom.PlayerCount <= GameConfigs.instance.maxTeamPlayers)
        //{
        //    InitializePlayer(photonTeams[0].Name, playerListings[0].transform);
        //}
        //else
        //{
        //    InitializePlayer(photonTeams[1].Name, playerListings[1].transform);

        //}


    }




    private void InitializePlayer(string teamName, Transform targetTransform)
    {
        GameObject intantiateContent = PhotonNetwork.Instantiate(playerContent.name,
        targetTransform.position,
        targetTransform.rotation);

        intantiateContent.transform.SetParent(targetTransform.transform);
        intantiateContent.transform.localScale = new Vector3(1, 1, 1);

        intantiateContent.GetComponent<SetPlayerTeam>().Initialize(PhotonNetwork.LocalPlayer,teamName);


    }




}


