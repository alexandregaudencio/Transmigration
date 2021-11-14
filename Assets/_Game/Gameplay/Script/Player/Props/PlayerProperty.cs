using Photon.Pun;
using UnityEngine;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class PlayerProperty : MonoBehaviourPunCallbacks
{
    PhotonView photonview;

    public static PlayerProperty instance;
    public string Team { get =>  photonview.Controller.GetPhotonTeam().Name; }
    public int maxHP =>  (int)photonview.Controller.CustomProperties["maxHP"];
       
    public int HP
    {
        get
        {
            return (int)photonview.Controller.CustomProperties["HP"];
        }
        set
        {
            int hp = (int)PV.Controller.CustomProperties["HP"];
            HashProperty["HP"] = hp + value;
            PV.Controller.SetCustomProperties(HashProperty);
        }
    }
    public void IncreaseHP(int value)
    {
        if(HP <= maxHP)
        {
            HP = value;

        }
    }

    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();

    private void Awake()
    {
        photonview = GetComponent<PhotonView>();
    }

    void Start()
    {
        gameObject.layer = GetLayer;
        //GetComponent<SpriteRenderer>().color = GetColor;
        instance = this;
    }

    //public Color GetColor => (Team == "Blue") ? GameConfigs.instance.TeamBColor : GameConfigs.instance.TeamAColor;

    public LayerMask GetLayer =>  LayerMask.NameToLayer((Team == "Blue") ? "TeamB" : "TeamA");

    public PhotonView PV { get => photonview; set => photonview = value; }

    public void ResetPlayerPrps(Vector3 spawnPosition)
    {
            //TODO: not working great.
            HashProperty["HP"] = (int)PhotonNetwork.LocalPlayer.CustomProperties["maxHP"];
            HashProperty["isDead"] = false;
        //HashProperty["timeToRespawn"] = GameConfigs.instance.timeToRespawn;
            PhotonNetwork.LocalPlayer.SetCustomProperties(HashProperty);
        //SetupGameplay setupGameplay = "";
        GetComponent<SpriteRenderer>().enabled = true;
            transform.position = spawnPosition;


    }
}
