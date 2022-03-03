using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoom : MonoBehaviourPunCallbacks
{
    
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
    }
}
