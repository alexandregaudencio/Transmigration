using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerDisplay;
    Timer timer;
    PhotonView PV;



    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        timer = GetComponent<Timer>();
    }


    private void OnEnable()
    {
        timer.CurrentTime = GameConfigs.instance.timeGameplay;
        timerDisplay.enabled = true;
    }


    private void FixedUpdate()
    {
        UIUpdate();
    }




    private void UIUpdate()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PV.RPC("SendTimer", RpcTarget.Others, timer.CurrentTime);
        }

        //string tempTimer = string.Format("{0:00}", timer.CurrentTime);
        timerDisplay.text = DisplayTime(timer.CurrentTime);
    }




    [PunRPC]
    private void SendTimer(float timeIn)
    {
        timer.CurrentTime = timeIn;
    }


    private string DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return  string.Format("{0:00}:{1:00}", minutes, seconds);
    }




}
