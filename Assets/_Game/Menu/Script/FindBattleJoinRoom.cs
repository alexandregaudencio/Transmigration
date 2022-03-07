using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBattleJoinRoom : MonoBehaviourPunCallbacks
{

    [SerializeField] private PlayerUserIDConteiner playerUserIDConteiner;
    [SerializeField] private PlayerUserIDConteiner userIDConteiner;

    //public string leadUserId
    //{
    //    get => PhotonNetwork.AuthValues.UserId;
    //}
    

    public string[] UsersArray
    {
        get
        {
            List<string> users = new List<string>();

            foreach (PlayerUserIDManager idManager in userIDConteiner.UserIDManagerListing)
            {
                users.Add(idManager?.PlayerUserID);
            }
            return users.ToArray();
        }
    }

    public void OnClick_FindBattle()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    private RoomOptions roomOptions
    {
        get
        {
            return new RoomOptions
            {
                MaxPlayers = (byte)GameConfigs.instance.MaxBattlePlayers,
                PublishUserId = true,
                IsOpen = true
                //IsVisible = !toggleTeam.isOn
            };
        }
    }


    string randomRoomName
    {
        get
        {
            return Random.Range(100, 999).ToString();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.JoinOrCreateRoom(randomRoomName, roomOptions, TypedLobby.Default, UsersArray
            );
    }

}
