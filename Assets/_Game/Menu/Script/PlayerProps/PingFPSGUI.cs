using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using UnityEngine;

public class PingFPSGUI : PhotonTeamsManager
{
    private ExitGames.Client.Photon.Hashtable hasIndexPlayer = new ExitGames.Client.Photon.Hashtable();
    Player[] playersTeam;
    PhotonView PV;
    private int ping;
    private float fps;
    //private float dt = 0.00f;
    //[SerializeField] private int targetFrameRate;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(SetFpsAndPing());
        //Application.targetFrameRate = targetFrameRate;
        PV = GetComponent<PhotonView>();

    }
    private void OnDestroy()
    {
        StopCoroutine(SetFpsAndPing());
    }


    //private void Update()
    //{
    //    ping = PhotonNetwork.GetPing();
    //    fps = (float)System.Math.Round(1.0f / dt, 1);
    //    dt += (Time.deltaTime - dt) * 0.1f;
    //}

    //define time e index do player
    //public void SetTeam(Player newPlayer)
    //{
    //    int roomPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
    //    Debug.Log("current room count: "+roomPlayerCount);
    //    if (roomPlayerCount % 2 == 1)
    //    {
    //        newPlayer.JoinTeam(2);
    //        TryGetTeamMembers(2, out playersTeam);
    //        SetIndexPlayer(newPlayer, playersTeam.Length);
    //    }
    //    else
    //    {
    //        newPlayer.JoinTeam(1);
    //        TryGetTeamMembers(1, out playersTeam);
    //        SetIndexPlayer(newPlayer, playersTeam.Length);
    //    }

    //}

    //TODO: FAZER EM RELAÇÃO AO TIME    
    //public void SetIndexPlayer(Player newPlayer, int index)
    //{
    //    hasIndexPlayer["indexPlayer"] = index;
    //    newPlayer.SetCustomProperties(hasIndexPlayer);   
    //}

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Ping: " + ping);
        GUI.Label(new Rect(10, 25, 100, 100), "FPS: " + fps);

        GUI.Label(new Rect(10, 50, 300, 100), "Players: " + PhotonNetwork.CurrentRoom?.PlayerCount);
        GUI.Label(new Rect(10, 60, 300, 100), "Blue: " + PhotonTeamsManager.Instance.GetTeamMembersCount(1).ToString());
        GUI.Label(new Rect(10, 70, 300, 100), "Red: " + PhotonTeamsManager.Instance.GetTeamMembersCount(2).ToString());
        
        GUI.Label(new Rect(10, 90, 300, 100), "HP: " + PhotonNetwork.LocalPlayer.CustomProperties["HP"].ToString());
        GUI.Label(new Rect(10, 100, 300, 100), "HP: " + PhotonNetwork.LocalPlayer.CustomProperties["isDead"].ToString());
        GUI.Label(new Rect(10, 110, 300, 100), "HP: " + PhotonNetwork.LocalPlayer.CustomProperties["damageTotal"].ToString());

        //GUI.Label(new Rect(10, 20, 100, 100), "FPS: " + FPS);

    }



    private IEnumerator SetFpsAndPing()
    {
        while (true)
        {
            ping = PhotonNetwork.GetPing();
            fps =  (int)(1f / Time.unscaledDeltaTime);
            yield return new WaitForSeconds(0.2f);
        }

    }




}
