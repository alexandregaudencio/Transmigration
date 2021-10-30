using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGame : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject startButton;

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        /*GetComponentInChildren<ge>().gameObject.SetActive*/
        if(PhotonNetwork.IsMasterClient)
        {
            byte playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            byte maxPlayers = PhotonNetwork.CurrentRoom.MaxPlayers;
            startButton.SetActive(( playerCount == maxPlayers ) ? true : false);

        } 
    }

    public void StartMatchmaking()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        StartCoroutine(waitToStart());
    }

    IEnumerator waitToStart()
    {
        yield return new WaitForSeconds(1);
        PhotonNetwork.LoadLevel(GameConfigs.instance.gameplaySceneIndex);

    }
}
