
using TMPro;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(MenuTimer))]
    public class MenuTimeManager : MonoBehaviour
    {
        private TMP_Text text_Time;
        private MenuTimer menuTimer;
        private void Awake()
        {
            menuTimer = GetComponent<MenuTimer>();
            text_Time = GetComponentInChildren<TMP_Text>();
        }

        private void OnEnable()
        {
            menuTimer.timerChange += UpdateTimerText;
            menuTimer.StartTime();

        }
        private void OnDisable()
        {
            menuTimer.timerChange -= UpdateTimerText;
            menuTimer.StopTime();
        }

        public  void UpdateTimerText(int time)
        {
            text_Time.SetText(time.ToString());
        }

    }
}
