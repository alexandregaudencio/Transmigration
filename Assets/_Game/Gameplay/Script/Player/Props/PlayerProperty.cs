using Photon.Pun;
using UnityEngine;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class PlayerProperty : MonoBehaviourPunCallbacks
{
    PhotonView photonview;

    public string Team { get =>  photonview.Controller.GetPhotonTeam().Name; }
    public int HP  =>  (int)photonview.Controller.CustomProperties["HP"]; 
    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();

    private void Awake()
    {
        photonview = GetComponent<PhotonView>();
    }

    void Start()
    {
        gameObject.layer = GetLayer;
        GetComponent<SpriteRenderer>().color = GetColor;
    }

    public Color GetColor => (Team == "Blue") ? GameConfigs.instance.TeamBColor : GameConfigs.instance.TeamAColor;

    public LayerMask GetLayer =>  LayerMask.NameToLayer((Team == "Blue") ? "TeamB" : "TeamA");

    public PhotonView PV { get => photonview; set => photonview = value; }

    public void ResetPlayerPrps(Vector3 spawnPosition)
    {
            //TODO: not working great.
            HashProperty["HP"] = (int)photonview.Controller.CustomProperties["maxHP"];
            HashProperty["isDead"] = false;
            //HashProperty["timeToRespawn"] = GameConfigs.instance.timeToRespawn;
            photonview.Controller.SetCustomProperties(HashProperty);
            //SetupGameplay setupGameplay = "";

            transform.position = spawnPosition;


    }
}
