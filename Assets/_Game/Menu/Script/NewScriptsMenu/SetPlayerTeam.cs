using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetPlayerTeam : MonoBehaviour
{
    public Player player;
    
    private PhotonTeam playerTeam => player?.GetPhotonTeam();
    public Player Player { get => player; set => player = value; }


    public SetPlayerTeam Initialize(Player player , string teamName)
    {
        this.player = player;
        player.JoinTeam(teamName);
        return this;
    }

    public void SwitchTeam(string teamName)
    {
        player.SwitchTeam(teamName);
    }

    


}
