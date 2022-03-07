using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class RoomPlayersContToText : MonoBehaviourPunCallbacks
{
    private TMP_Text text_teamPlayersCount;

    private void Awake()
    {
        text_teamPlayersCount = GetComponent<TMP_Text>();
    }

    //public override void OnEnable()
    //{
    //    UpdateTeamPlayersCountText();
    //}


    public override void OnJoinedRoom()
    {
        text_teamPlayersCount.text = "...";
        UpdateTeamPlayersCountText();
    }
    public override void OnLeftRoom()
    {
        text_teamPlayersCount.text = "...";

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdateTeamPlayersCountText();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateTeamPlayersCountText();
    }

    private void UpdateTeamPlayersCountText()
    {
        text_teamPlayersCount.text = PhotonNetwork.CurrentRoom.PlayerCount + " of " + GameConfigs.instance.MaxBattlePlayers;
    }


}
