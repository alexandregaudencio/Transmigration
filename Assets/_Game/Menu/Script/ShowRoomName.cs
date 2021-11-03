using Photon.Pun;

using UnityEngine.UI;

public class ShowRoomName : MonoBehaviourPunCallbacks
{

    public override void OnJoinedRoom()
    {
        GetComponent<Text>().text = PhotonNetwork.CurrentRoom.Name;
    }

}
