using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Collections;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TeamManager teamManager;
    [SerializeField] private Text playerCountText;

    private void Start()
    {
        GetComponent<AudioSource>().Play();
    }



    //public void JoinRoom()
    //{
    //    PhotonNetwork.JoinRandomRoom();
    //}

    public void LeaveRoom()
    {
        //PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveRoom(true);
        playerCountText.text = "...";

    }

    //public override void OnJoinRandomFailed(short returnCode, string message)
    //{
    //    string roomName = Random.Range(100, 999).ToString();
    //    RoomOptions roomOptions = new RoomOptions()
    //    {
    //        MaxPlayers = (byte)GameConfigs.instance.maxRoomPlayers,
    //        IsOpen = true, 
    //        IsVisible = true

    //    };
    //    PhotonNetwork.CreateRoom(roomName, roomOptions);
    //    Debug.Log("criei a sala: " + roomName);
    //}


    //QUANDO O LOCAL ENTRA NA SALA
    public override void OnJoinedRoom()
    {
        
        //define seu time quando entra na sala
        teamManager.SetTeam(PhotonNetwork.LocalPlayer);
        //GetComponent<PlayerPropertiesDefinition>().SetCharacter();
        Debug.Log("Entrei na sala: "+PhotonNetwork.CurrentRoom.Name);

        UpdatePlayercountText();


    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined LOBBY.");
    }
    public override void OnLeftLobby()
    {
        Debug.Log("Left LOBBY.");
    }


    //QUANDO ALGUÉM ENTRA NA SALA
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayercountText();
    }

    //AÇÃO BOTÃO START



    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("One Player Left ROOM.");
        UpdatePlayercountText();
    }




    private void UpdatePlayercountText()
    {
        playerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount + " of " + PhotonNetwork.CurrentRoom.MaxPlayers;
    }



}
