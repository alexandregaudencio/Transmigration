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

    public SetupGameplay instance;


    void Start()
    {
        text.text = "IndexPlayer: " + indexPlayer + " " + PhotonNetwork.LocalPlayer.TagObject.ToString();

        indexPlayer = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        pTeam = PhotonNetwork.LocalPlayer.GetPhotonTeam().Name;
        InstantiatingPlayersCharacter();

        instance = this;

    }

    private void InstantiatingPlayersCharacter()
    {
        //int indexPlayer = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        //string pTeam = PhotonNetwork.LocalPlayer.GetPhotonTeam().Name;
        if (pTeam == "Blue")
        {
            PV.RPC("RPCInstantiateCharacter", PhotonNetwork.LocalPlayer, spawnPointsBlue[indexPlayer].position);
            //PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPointsBlue[indexPlayer].position, Quaternion.identity);

        }
        if (pTeam == "Red")
        {
            PV.RPC("RPCInstantiateCharacter", PhotonNetwork.LocalPlayer, spawnPointsRed[indexPlayer].position);
            //PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPointsRed[indexPlayer].position, Quaternion.identity);
        }
    }

    [PunRPC]
    public void RPCInstantiateCharacter(Vector3 spawnPos)
    {

        PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPos, Quaternion.identity);
    }

    public Vector3 LocalPlayerSpawnPoint => (pTeam == "Blue") ? spawnPointsBlue[indexPlayer].position : spawnPointsRed[indexPlayer].position;

}
