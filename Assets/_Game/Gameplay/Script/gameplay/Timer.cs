using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{


    float currentTime;
    float baseTime;
    float maxTime;
    float timePassed;

    //Timer(float maxTime, float baseTime = 1.0000f)
    //{
    //    this.maxTime = maxTime;
    //}


    public float CurrentTime { get => currentTime; set => currentTime = value; }
    public float BaseTime { get => baseTime; set => baseTime = value; }

    public bool IsCountdownOver()
    {
        return (CurrentTime > 0.0f) ? false : true;
    }
    public bool IsBasedownOver()
    {
        return (BaseTime > 0.0f) ? false : true;
    }
    public bool IsCountdownStart()
    {
        timePassed = GameConfigs.instance.TimeGameplay - CurrentTime;
        return (timePassed < 5) ? false : true;
    }

    private void FixedUpdate()
    {
        if (CurrentTime >= 0) CurrentTime -= Time.fixedDeltaTime;
        if (BaseTime >= 0) BaseTime -= Time.fixedDeltaTime;
    }






    //private void Start()
    //{
    //    StartCoroutine(TimerUpdate());
    //}

    //private void OnEnable()
    //{
        
    //}
    //private void OnDisable()
    //{
    //    StopCoroutine(TimerUpdate());
    //}

    //IEnumerator TimerUpdate()
    //{
    //    int timePassed = 0;
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(BaseTime);
    //        timePassed++;
    //        //currentTime++;
            
    //    }
    //}

}
