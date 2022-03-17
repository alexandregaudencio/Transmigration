using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System;
using UnityEngine;

public class PlayerTeam : MonoBehaviourPunCallbacks
{
    private Player player;
    public PhotonTeam playerTeam => player?.GetPhotonTeam();
    public Player Player => player;

    public event Action InitializeContentEvent; 

    public override void OnEnable()
    {
        PhotonTeamsManager.PlayerLeftTeam += DestroyPlayerTeamContent;
    }
    
    public override void OnDisable()
    {
        PhotonTeamsManager.PlayerLeftTeam -= DestroyPlayerTeamContent;
        Destroy(gameObject);
    }

    public PlayerTeam InitializeContent(Player player /*, string teamName*/)
    {
        
        this.player = player;
        InitializeContentEvent?.Invoke();
        return this;
    }

    public void SwitchTeam(string teamName)
    {
        player.SwitchTeam(teamName);
    }
 
    void DestroyPlayerTeamContent(Player player, PhotonTeam pteam)
    {
        if(this.player == player)
        {
            Destroy(gameObject);
        }
    }


}
