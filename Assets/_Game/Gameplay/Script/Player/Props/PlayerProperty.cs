using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.UtilityScripts;

public class PlayerProperty : MonoBehaviourPunCallbacks
{
    PhotonView PV;


    public string Team { get =>  PV.Controller.GetPhotonTeam().Name; }
    public int HP  =>  (int)PV.Controller.CustomProperties["HP"]; 
    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        gameObject.layer = GetLayer;
        GetComponent<SpriteRenderer>().color = GetColor;
    }

    public Color GetColor => (Team == "Blue") ? GameConfigs.instance.TeamBColor : GameConfigs.instance.TeamAColor;

    public LayerMask GetLayer =>  LayerMask.NameToLayer((Team == "Blue") ? "TeamB" : "TeamA");

    
    public void ResetPlayerPrps()
    {
        //TODO: not working great.
        HashProperty["HP"] = (int)PV.Controller.CustomProperties["maxHP"];
        HashProperty["isDead"] = false;
        //HashProperty["timeToRespawn"] = GameConfigs.instance.timeToRespawn;
        PV.Controller.SetCustomProperties(HashProperty);
        //SetupGameplay setupGameplay = "";
        
        transform.position =   FindObjectOfType<SetupGameplay>().LocalPlayerSpawnPoint;


    }
}
