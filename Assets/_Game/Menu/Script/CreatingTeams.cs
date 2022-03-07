using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingTeams : MonoBehaviourPunCallbacks, IMatchmakingCallbacks
{
    ////string[] expectedUsers;
    //string[] teamMembersUserId;

    ////public string[] ExpectedUsers { get => expectedUsers; set => expectedUsers = value; }
    //public string[] TeamMembersUserId { get => teamMembersUserId; set => teamMembersUserId = value; }

    //LoadBalancingClient loadBalancingClient = new LoadBalancingClient();




    //private void JoinBattleRoom()
    //{

    //    OpJoinRandomRoomParams opJoinRandomRoomParams = new OpJoinRandomRoomParams();
    //    opJoinRandomRoomParams.ExpectedUsers = TeamMembersUserId;
    //    loadBalancingClient.OpJoinRandomRoom(opJoinRandomRoomParams);

    //}

    //RoomOptions battleRoomOptions = new RoomOptions()
    //{
    //    MaxPlayers = GameConfigs.instance.maxRoomPlayers
    //};

    //public string leadUserId;


    //IEnumerator MasterMigration()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    if (loadBalancingClient.OpFindFriends(new string[1] { leadUserId }))
    //    {

    //    }
    //}

    ////Players others chamam
    //public void OnMasterMigration()
    //{
    //    EnterRoomParams enterRoomParams = new EnterRoomParams();

    //    //enterRoomParams.RoomName = roomNameWhereTheLeaderIs;
    //    loadBalancingClient.OpJoinRoom(enterRoomParams);
    //}


    //public void JoinOrCreatePrivateRoom(string nameEveryFriendKnows)
    //{
    //    RoomOptions roomOptions = new RoomOptions();
    //    roomOptions.IsVisible = false;
    //    EnterRoomParams enterRoomParams = new EnterRoomParams();
    //    enterRoomParams.RoomName = nameEveryFriendKnows;
    //    enterRoomParams.RoomOptions = roomOptions;
    //    loadBalancingClient.OpJoinOrCreateRoom(enterRoomParams);
    //}


    //void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message)
    //{
    //    // log error code and message
    //}

    //void IMatchmakingCallbacks.OnJoinedRoom()
    //{
    //    // joined a room successfully, OpJoinOrCreateRoom leads here on success
    //}

}
