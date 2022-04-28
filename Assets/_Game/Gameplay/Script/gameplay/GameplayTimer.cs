using Managers;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class GameplayTimer : MonoBehaviour
{
    private TMP_Text text_Time;
    private Timer timer;

    public Timer Timer { get => timer; set => timer = value; }

    private void Awake()
    {
        Timer = GetComponent<Timer>();
        text_Time = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        Timer.timerChange += SetTimerText;
        Timer.StartTime();

    }
    private void OnDisable()
    {
        Timer.timerChange -= SetTimerText;
        Timer.StopTime();
    }

    //public void UpdateTimerText(int time)
    //{
    //    text_Time.SetText(time.ToString());
    //}

    private void SetTimerText(float timeToDisplay)
    {
        text_Time.SetText(timer.StringTimeFormated());
    }




}
