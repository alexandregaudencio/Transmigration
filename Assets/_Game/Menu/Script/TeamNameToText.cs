using Photon.Pun;

using UnityEngine.UI;

public class TeamNameToText : MonoBehaviourPunCallbacks
{
    private Text text_TeamName;


    private void Awake()
    {
        text_TeamName = GetComponent<Text>();
    }
    public override void OnJoinedRoom()
    {
         text_TeamName.text  = "#"+PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnLeftRoom()
    {
        text_TeamName.text = "#...";
    }




}
