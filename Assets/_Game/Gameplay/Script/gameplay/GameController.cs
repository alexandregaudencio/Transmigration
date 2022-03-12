using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    TimerController timerController;
    

    private void Start()
    {
        timerController = GetComponent<TimerController>();

        //GameObject teamManagerObject =  ;
        //Debug.Log(teamManagerObject.name);
        if(PhotonNetwork.IsMasterClient)
        SceneManager.MoveGameObjectToScene(FindObjectOfType<TeamManagerAndProps>()?.gameObject, SceneManager.GetActiveScene());

    }


    private void Update()
    {

        if (timerController.Timer.IsCountdownOver())
        {
            EndGame();
        }
    }


    public void EndGame()
    {
        //if (!PhotonNetwork.IsMasterClient) return;
        ResetGameConfig();
        SceneManager.LoadScene(GameConfigs.instance.menuSceneIndex);

        //PhotonNetwork.LoadLevel(GameConfigs.instance.menuSceneIndex);

    }


    //temporário;
    //public void ReturntoMenuScene()
    //{
    //    ResetGameConfig();

    //}

    private void ResetGameConfig()
    {
        //GameObject g =  FindObjectOfType<TeamManager>().gameObject; 

       PhotonTeamExtensions.LeaveCurrentTeam(PhotonNetwork.LocalPlayer);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        //PhotonNetwork.Disconnect();
        //Destroy(FindObjectOfType<TeamManager>().gameObject);
        //FindObjectOfType<TeamManager>().LeaveTeamLocalPlayer();
    }



}
