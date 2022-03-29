using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{

    public class MenuTimer : MonoBehaviour
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
             

    }

}
