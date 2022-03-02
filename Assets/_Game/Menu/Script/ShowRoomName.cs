using Photon.Pun;

using UnityEngine.UI;

public class ShowRoomName : MonoBehaviourPunCallbacks
{
    private Text text_Team;


    private void Awake()
    {
        text_Team = GetComponent<Text>();
    }
    public override void OnJoinedRoom()
    {
         text_Team.text  = "#"+PhotonNetwork.CurrentRoom.Name;
        
    }

    public override void OnLeftRoom()
    {
        text_Team.text = "#...";
    }




}
