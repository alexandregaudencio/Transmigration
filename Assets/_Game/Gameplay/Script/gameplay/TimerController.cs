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


    private void Start()
    {
        timer.CurrentTime = GameConfigs.instance.timeGameplay;
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
        string tempTimer = string.Format("{0:00}", timer.CurrentTime);
        timerDisplay.text = tempTimer;
    }




    [PunRPC]
    private void SendTimer(float timeIn)
    {
        timer.CurrentTime = timeIn;
    }







}
