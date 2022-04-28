using Managers;
using System;
using TMPro;
using UnityEngine;

public class StartupTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text text_Time;
    private Timer timer;
    public event Action StartupTimeOver;

    private void Awake()
    {
        timer = GetComponent<Timer>();
        //text_Time = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        timer.timerChange += UpdateTimerText;
        timer.timeOver += OnStartupTimeOver;
    }

    private void Start()
    {
        timer.StartTime();

    }

    private void OnDisable()
    {
        timer.timerChange -= UpdateTimerText;
        timer.timeOver -= OnStartupTimeOver;
        timer.StopTime();
    }

    public void OnStartupTimeOver()
    {
        StartupTimeOver?.Invoke();
    }

    public void UpdateTimerText(float time)
    {
        text_Time.SetText(time.ToString());
    }



}
