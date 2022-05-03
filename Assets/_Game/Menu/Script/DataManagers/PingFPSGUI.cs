
using System.Collections;
using UnityEngine;

public class PingFPSGUI : MonoBehaviour
{
    private float fps;
    //[SerializeField] private int targetFrameRate;
    [Range(1,6)] public int joystickPlayerIndex;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(SetFpsAndPing());
        //Application.targetFrameRate = targetFrameRate;

    }
    private void OnDestroy()
    {
        StopCoroutine(SetFpsAndPing());
    }


    private void OnGUI()
    {
        GUI.Label(new Rect(5, 5, 500, 100), "FPS: " + fps);
        //GUI.Label(new Rect(10, 40, 500, 100), 
        //    "LAxis: " + 
        //    Input.GetAxis("Joy"+ joystickPlayerIndex+"LHorizontal") + " "+
        //    Input.GetAxis("Joy" + joystickPlayerIndex + "LVertical"));
        //GUI.Label(new Rect(10, 60, 500, 100),
        //    "RAxis: " +
        //    Input.GetAxis("Joy" + joystickPlayerIndex + "RHorizontal") + " " +
        //    Input.GetAxis("Joy" + joystickPlayerIndex + "RVertical"));

    }



    private IEnumerator SetFpsAndPing()
    {
        while (true)
        {
            fps =  (int)(1f / Time.unscaledDeltaTime);
            yield return new WaitForSeconds(0.3f);
        }

    }




}
