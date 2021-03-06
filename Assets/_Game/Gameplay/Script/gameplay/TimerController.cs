using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerDisplay;
    private Timer timer;
    private PhotonView PV;


    private AudioSource audioSource;
    [SerializeField] private AudioClip gameplayMusic;

    public Timer Timer { get => timer; set => timer = value; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PV = GetComponent<PhotonView>();
        Timer = GetComponent<Timer>();
    }


    private void OnEnable()
    {
        Timer.CurrentTime = GameConfigs.instance.TimeGameplay;
        timerDisplay.enabled = true;

        audioSource.clip = gameplayMusic;
        audioSource.Play();
    }


    private void FixedUpdate()
    {
        UIUpdate();
    }




    private void UIUpdate()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PV.RPC("SendTimer", RpcTarget.Others, Timer.CurrentTime);
        }

        //string tempTimer = string.Format("{0:00}", timer.CurrentTime);
        timerDisplay.text = DisplayTime(Timer.CurrentTime);
    }




    [PunRPC]
    private void SendTimer(float timeIn)
    {
        Timer.CurrentTime = timeIn;
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
