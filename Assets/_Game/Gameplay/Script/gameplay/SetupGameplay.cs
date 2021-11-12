using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;

public class SetupGameplay : MonoBehaviour
{
    private PhotonView PV;

    [SerializeField] private Transform[] spawnPointsBlue, spawnPointsRed;
    public Text text;
    int indexPlayer;
    string pTeam;
    public GameObject localCamera;
    public static SetupGameplay instance;

    void Start()
    {
        instance = this;

        indexPlayer = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        pTeam = PhotonNetwork.LocalPlayer.GetPhotonTeam().Name;
        InstantiatingPlayersCharacter();
        //text.text = "IndexPlayer: " + indexPlayer + " " + PhotonNetwork.LocalPlayer.TagObject.ToString();
        
        //PhotonNetwork.Instantiate("PlayerA", spawnPointsBlue[indexPlayer].position, Quaternion.identity);

    }

    void Update()
      {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("IndexPlayer: " + indexPlayer + " / " + PhotonNetwork.LocalPlayer.TagObject.ToString());
        }
     }

    private void InstantiatingPlayersCharacter()
    {
        //int indexPlayer = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        //string pTeam = PhotonNetwork.LocalPlayer.GetPhotonTeam().Name;
        if (pTeam == "Blue")
        {
            //PV.RPC("RPCInstantiateCharacter", PhotonNetwork.LocalPlayer, spawnPointsBlue[indexPlayer].position);
         GameObject instantiate =    PhotonNetwork.Instantiate("PlayerA", spawnPointsBlue[indexPlayer].position, Quaternion.identity);
        }
        if (pTeam == "Red")
        {
            //PV.RPC("RPCInstantiateCharacter", PhotonNetwork.LocalPlayer, spawnPointsRed[indexPlayer].position);
         GameObject instantiate = PhotonNetwork.Instantiate("PlayerA", spawnPointsRed[indexPlayer].position, Quaternion.identity);
        
        }
    }

    [PunRPC]
    public void RPCInstantiateCharacter(Vector3 spawnPos)
    {

        PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPos, Quaternion.identity);
    }

    public Vector3 LocalPlayerSpawnPoint => (pTeam == "Blue") ? spawnPointsBlue[indexPlayer].position : spawnPointsRed[indexPlayer].position;

}
