using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;

public class TeamManager : PhotonTeamsManager
{
    private ExitGames.Client.Photon.Hashtable hasIndexPlayer = new ExitGames.Client.Photon.Hashtable();
    Player[] playersTeam;

    private int FPS;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("Start TEAMmANAGER SCRIPT");

        InvokeRepeating("SetFPS", 1, 1);

    }

    //define time e index do player
    public void SetTeam(Player newPlayer)
    {
        int roomPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log("current room count: "+roomPlayerCount);
        if (roomPlayerCount % 2 == 1)
        {
            newPlayer.JoinTeam(2);
            TryGetTeamMembers(2, out playersTeam);
            SetIndexPlayer(newPlayer, playersTeam.Length);
        }
        else
        {
            newPlayer.JoinTeam(1);
            TryGetTeamMembers(1, out playersTeam);
            SetIndexPlayer(newPlayer, playersTeam.Length);
        }

    }

    //TODO: FAZER EM RELAÇÃO AO TIME    
    public void SetIndexPlayer(Player newPlayer, int index)
    {
        hasIndexPlayer["indexPlayer"] = index;
        newPlayer.SetCustomProperties(hasIndexPlayer);   
    }

    private void OnGUI()
    {

        //string[] members;
        ////TryeGetTeammenbers(1, Player
         GUI.Label(new Rect(10, 30, 300, 100), "Players: "+PhotonNetwork.CurrentRoom?.PlayerCount);

        GUI.Label(new Rect(10, 40, 300, 100), "TeamA: "+GetTeamMembersCount(1).ToString());
        GUI.Label(new Rect(10, 50, 300, 100), "TeamB: " + GetTeamMembersCount(2).ToString());
        GUI.Label(new Rect(10, 70, 300, 100), "Room: " + PhotonNetwork.CurrentRoom?.Name);

        if (PhotonNetwork.IsMasterClient) GUI.Label(new Rect(10, 100, 300, 100), "Você é o Master.");

        GUI.Label(new Rect(10, 10, 100, 100), "Ping: "+PhotonNetwork.GetPing());
        //GUI.Label(new Rect(10, 20, 100, 100), "FPS: " + FPS);

    }

    private void SetFPS()
    { 
      FPS =  (int)(1f / Time.unscaledDeltaTime);

        
    }
}
