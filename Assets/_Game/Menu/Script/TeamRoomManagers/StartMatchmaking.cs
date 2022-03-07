using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Ajustar esta pasta
public class StartMatchmaking : MonoBehaviourPunCallbacks
{


    //TODO: Só funciona InLobby
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo item in roomList)
        {
            if (item.MaxPlayers == GameConfigs.instance.MaxBattlePlayers)
            {
                Debug.Log("RoomBattlhe: " + item.Name);
            }

        }
    }


    //quando o btão de start game é apertado
    public void OnClick_StartMatchMaking()
    {
        //deve ser feito pelo MASTERCLIENT e quando ta lotado e quando não ta lotado.
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        //StartCoroutine(waitToStart());
        teamMembersUserId = TeamMenbersUserID();
        //leadUserId =  LeadUserID();
        PhotonNetwork.LeaveRoom(true);
        //CreateBattleRoom();
    }

 
    private string[] TeamMenbersUserID()
    {
        List<string> playersUsersID = new List<string>();
        foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            playersUsersID.Add(player.UserId);
        }
        return playersUsersID.ToArray();
    }

    //IEnumerator waitToStart()
    //{
    //    yield return new WaitForSeconds(1);
    //    PhotonNetwork.LoadLevel(GameConfigs.instance.gameplaySceneIndex);

    //}
    private string leadUserId;

    string[] teamMembersUserId;
    public string[] TeamMembersUserId { get => teamMembersUserId; set => teamMembersUserId = value; }

    LoadBalancingClient loadBalancingClient = new LoadBalancingClient();


    //RoomOptions battleRoomOptions = new RoomOptions()
    //{
    //    MaxPlayers = (byte)GameConfigs.instance.MaxBattlePlayers,
    //    PublishUserId = true
        
    //};

    //private void CreateBattleRoom()
    //{
    //    EnterRoomParams enterRoomParams = new EnterRoomParams();
    //    enterRoomParams.RoomName = "firstBattleRoom";
    //    enterRoomParams.RoomOptions = battleRoomOptions;

    //    enterRoomParams.ExpectedUsers = TeamMembersUserId;
    //    loadBalancingClient.OpCreateRoom(enterRoomParams);
    //}



}
