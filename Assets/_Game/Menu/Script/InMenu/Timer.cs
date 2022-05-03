using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{

    public class Timer : MonoBehaviour
    {
        [SerializeField] private float maxTimeInSeconds;
        [SerializeField] private float deltaTime;
        public Action  onTimeOver;
        public  Action timeInitalize;
        public Action<float> timerChange;
        private float currentTime;
        public static Timer instance;
        public float timePassed => (maxTimeInSeconds - currentTime);
        public float CurrentTime { get => currentTime; }

        public bool IsTimeOver => (CurrentTime > 0.00f) ? false : true;

        public void ResetTime() => currentTime = maxTimeInSeconds;

        public void StartTime()
        {
            timeInitalize?.Invoke();
        }
        public void StopTime()
        {
            StopCoroutine(TimerCountdown());
            ResetTime();
        }

        private void OnEnable()
        {
            ResetTime();
            timeInitalize += OnTimeInitialize;
        }

        private void OnDisable()
        {
            timeInitalize -= OnTimeInitialize;
            StopTime();
        }

        private void Start()
        {
            instance = this;
        }

        public void OnTimeInitialize()
        {
            currentTime = maxTimeInSeconds; //correção
            StartCoroutine(TimerCountdown());
        }


        private IEnumerator TimerCountdown()
        {
            while(!IsTimeOver)
            {
                currentTime -= deltaTime;
                timerChange?.Invoke(currentTime);
                if (IsTimeOver) onTimeOver?.Invoke();
                yield return new WaitForSeconds(deltaTime);
                
            }

        }

        public string StringTimeFormated()
        {
            if (currentTime < 0) currentTime = 0;
           
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }


    }

}
