using Managers;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartupTimer : MonoBehaviour
{
    private TMP_Text text_Time;
    private Timer timer;
    private void Awake()
    {
        timer = GetComponent<Timer>();
        text_Time = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        timer.timerChange += UpdateTimerText;

    }

    private void OnDisable()
    {
        timer.timerChange -= UpdateTimerText;
        timer.StopTime();
    }

    private void Start()
    {
        timer.StartTime();
    }

    public void UpdateTimerText(int time)
    {
        text_Time.SetText(time.ToString());
    }



}
