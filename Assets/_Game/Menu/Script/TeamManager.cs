using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class TeamManager : PhotonTeamsManager
{
    private ExitGames.Client.Photon.Hashtable hasIndexPlayer = new ExitGames.Client.Photon.Hashtable();
    Player[] playersTeam;
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

    }


    //define time e index do player
    public void SetTeam(Player newPlayer)
    {
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount % 2 == 1)
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


}
