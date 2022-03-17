using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefineTeamPlayers : MonoBehaviourPunCallbacks
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
    }

    public void OnClick_DefineTeamPlayers()
    {
        PhotonNetwork.LoadLevel(GameConfigs.instance.gameplaySceneIndex);
    }

    public void ActiveButtonInteractable(Player player, PhotonTeam pt)
    {
        PhotonTeam[] photonTeam = PhotonTeamsManager.Instance.GetAvailableTeams();
        for (int i = 0; i < photonTeam.Length; i++)
        {
            if(PhotonTeamsManager.Instance.GetTeamMembersCount(photonTeam[i].Code) < GameConfigs.instance.maxTeamPlayers)
            {
                button_DefineTeam.interactable = false;
                text_buttonMessage.SetText("Aguardando...");

                return;
            }
            button_DefineTeam.interactable = true;
            text_buttonMessage.SetText("Começar!");

        
        }
    }

}
