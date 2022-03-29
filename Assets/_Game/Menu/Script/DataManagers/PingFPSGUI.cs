
using System.Collections;
using UnityEngine;

public class PingFPSGUI : MonoBehaviour
{
    private float fps;
    //[SerializeField] private int targetFrameRate;

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
        GUI.Label(new Rect(10, 25, 100, 100), "FPS: " + fps);
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
