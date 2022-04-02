using Managers;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayTimer : MonoBehaviour
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
        timer.timerChange += FormatedTime;
        timer.StartTime();

    }
    private void OnDisable()
    {
        timer.timerChange -= FormatedTime;
        timer.StopTime();
    }

    //public void UpdateTimerText(int time)
    //{
    //    text_Time.SetText(time.ToString());
    //}

    private void FormatedTime(int timeToDisplay)
    {
        if (timeToDisplay <= 0) 
            timeToDisplay = 0;
        else if (timeToDisplay > 0) 
            timeToDisplay += 1;

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        text_Time.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }




}
