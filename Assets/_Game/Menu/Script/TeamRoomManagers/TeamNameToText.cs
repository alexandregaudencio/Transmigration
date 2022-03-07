using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class TeamNameToText : MonoBehaviourPunCallbacks
{
    private TMP_Text text_TeamName;

    private void Awake()
    {
        text_TeamName = GetComponent<TMP_Text>();
    }

    //public new void OnEnable()
    //{
    //    text_TeamName.text = "#" + PhotonNetwork.CurrentRoom.Name;
    //}

    //public new void OnDisable()
    //{
    //    text_TeamName.text = "#...";

    //}
    public override void OnJoinedRoom()
    {
        text_TeamName.text = "#" + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnLeftRoom()
    {
        text_TeamName.text = "#...";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        text_TeamName.text = "#" + PhotonNetwork.CurrentRoom.Name;

    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        text_TeamName.text = "#" + PhotonNetwork.CurrentRoom.Name;

    }


}
