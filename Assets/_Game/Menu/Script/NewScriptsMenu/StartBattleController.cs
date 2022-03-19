using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartBattleController : MonoBehaviourPunCallbacks
{
    private Button button_DefineTeam;
    private TMP_Text text_buttonMessage;

    private void Awake()
    {
        button_DefineTeam = GetComponent<Button>();
        text_buttonMessage = GetComponentInChildren<TMP_Text>();

    }
   

    public override void OnEnable()
    {
        PhotonTeamsManager.PlayerJoinedTeam += ActiveButtonInteractable;
    }
    public override void OnDisable()
    {
        PhotonTeamsManager.PlayerJoinedTeam += ActiveButtonInteractable;
        StopCoroutine("WaitToStart");
    }


    public void ActiveButtonInteractable(Player player, PhotonTeam pt)
    {
        PhotonTeam[] photonTeam = PhotonTeamsManager.Instance.GetAvailableTeams();
        for (int i = 0; i < photonTeam.Length; i++)
        {
            if(PhotonTeamsManager.Instance.GetTeamMembersCount(photonTeam[i].Code) < GameConfigs.instance.MaxTeamPlayers)
            {
                button_DefineTeam.interactable = false;
                text_buttonMessage.SetText("Aguardando...");

                return;
            }
            button_DefineTeam.interactable = true;
            text_buttonMessage.SetText("Começar!");

        
        }
    }


    public void OnClick_LoadLevel()
    {
        StartCoroutine(WaitToStart(2));
    }

    private IEnumerator WaitToStart(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        PhotonNetwork.LoadLevel(GameConfigs.instance.GameplaySceneIndex);

    }

    //private IEnumerator  CheckPlayersTagObject()
    //{
    //    Player[] player = 
    //    while (isplayersTagObjectNull) { 
    //        foreach (Player player in PhotonNetwork.PlayerList)
    //        {
    //            if (player.TagObject == null)
    //            {
    //                isplayersTagObjectNull = true;
    //                break;
    //            }
    //        }



    //    }

    //}

}
