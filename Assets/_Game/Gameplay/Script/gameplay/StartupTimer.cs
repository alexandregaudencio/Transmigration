using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartupTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerDisplay;
    Timer timer;
    PhotonView PV;
    [SerializeField] private List<GameObject> BlockZoneObjects;

    AudioSource audioSource;
    public AudioClip startupMusic;
    public Event  newevent;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        timer = GetComponent<Timer>();
        audioSource = GetComponent<AudioSource>();

    }
    private void OnEnable()
    {
        timer.CurrentTime = GameConfigs.instance.Timestartup;
        audioSource.clip = startupMusic;
        audioSource.Play();
    }

    private void FixedUpdate()
    {
        UIUpdate();

        if(timer.CurrentTime <= 0)
        {
            StartGameplay();
        }
        
    }

    private void UIUpdate()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PV.RPC("SendStartUpTime", RpcTarget.Others, timer.CurrentTime);
          
        }

        //string tempTimer = string.Format("{0:00}", timer.CurrentTime);
        int formated = (int)timer.CurrentTime;
        timerDisplay.text = formated.ToString();
    }



    [PunRPC]
    private void SendStartUpTime(float timeIn)
    {
        timer.CurrentTime = timeIn;
    }


    void StartGameplay()
    {
        GetComponent<TimerController>().enabled = true;
        GetComponent<ObjectHandle>().enabled = true;
        
        foreach (GameObject objects in BlockZoneObjects)
        {
            objects.SetActive(false);
        }
    }



}
