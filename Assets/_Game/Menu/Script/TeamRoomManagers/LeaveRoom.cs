using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoom : MonoBehaviourPunCallbacks
{
    
    public void OnClick_LeaveRoom()
    {

        //TODO: incluir desconex�o
        PhotonNetwork.LeaveRoom(false);
    }
}
