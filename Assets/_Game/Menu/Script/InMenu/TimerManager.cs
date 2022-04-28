
using TMPro;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(Timer))]
    public class TimerManager : MonoBehaviour
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
            timer.StartTime();

        }
        private void OnDisable()
        {
            timer.timerChange -= UpdateTimerText;
            timer.StopTime();
        }

        public  void UpdateTimerText(float time)
        {
            text_Time.SetText(time.ToString());
        }

    }
}
