using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{

    public class Timer : MonoBehaviour
    {
        [SerializeField] private int maxTimeInSeconds;
        public Action  timeOver;
        public  Action timeInitalize;
        public Action<int> timerChange;
        private int currentTime;

        public int timePassed => (maxTimeInSeconds - currentTime);
        public int CurrentTime { get => currentTime; }

        public bool IsTimeOver => (CurrentTime > 0.00f) ? false : true;

        public void ResetTime() => currentTime = maxTimeInSeconds + 1;


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
        public void OnTimeInitialize()
        {
            currentTime = maxTimeInSeconds+1; //correção
            StartCoroutine(TimerCountdown());
        }


        private IEnumerator TimerCountdown()
        {
            while(!IsTimeOver)
            {
                currentTime--;
                timerChange?.Invoke(currentTime);
                if (IsTimeOver) timeOver?.Invoke();
                yield return new WaitForSeconds(1);
                
            }

        }

        private string StringTimeFormated()
        {
            if (currentTime < 0)
            {
                currentTime = 0;
            }
            else if (currentTime > 0)
            {
                currentTime += 1;
            }

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }


    }

}
