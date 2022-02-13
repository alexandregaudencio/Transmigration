using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    TimerController timerController;
    

    private void Start()
    {
        timerController = GetComponent<TimerController>();

    }

    private void EndGame()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        PhotonNetwork.LoadLevel(GameConfigs.instance.menuSceneIndex);

    }

    private void Update()
    {

        if (timerController.Timer.IsCountdownOver())
        {
            EndGame();
        }
    }





}
