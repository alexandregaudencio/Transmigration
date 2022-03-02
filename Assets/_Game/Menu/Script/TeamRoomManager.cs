using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Collections;
using UnityEngine.UI;

public class TeamRoomManager : MonoBehaviourPunCallbacks
{
    //TODO: Remover
    [SerializeField] private TeamManagerAndProps teamManager;

    private void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);

    }

    //public override void OnJoinedRoom()
    //{
    //    teamManager.SetTeam(PhotonNetwork.LocalPlayer);


    //}

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined LOBBY.");
    }
    public override void OnLeftLobby()
    {
        Debug.Log("Left LOBBY.");
    }



}
