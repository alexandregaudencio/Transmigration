using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyDisconnection : MonoBehaviour
{
  public void OnClick_Disconnect()
    {
        PhotonNetwork.Disconnect();
    }
}
