
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
        }
        private void OnDisable()
        {
            menuTimer.timerChange -= UpdateTimerText;
        }
        private void Start()
        {
            menuTimer.StartTime();
        }

        public  void UpdateTimerText(int time)
        {
            text_Time.text = (time.ToString());
        }

    }
}
