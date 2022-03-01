using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGameplay : MonoBehaviour
{
    private PhotonView PV;

    [SerializeField] private Transform[] spawnPointsBlue, spawnPointsRed;
    [SerializeField] private GameObject[] charactersOrdered;
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

   

    private void InstantiatingPlayersCharacter()
    {
        //int indexPlayer = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        //string pTeam = PhotonNetwork.LocalPlayer.GetPhotonTeam().Name;

        //TODO: trocar o index de charactersOrdered pelo personagem escolhido
        if (pTeam == "Blue")
        {
            //PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPos, Quaternion.identity);

            GameObject instantiate =  PhotonNetwork.Instantiate(charactersOrdered[0].name , spawnPointsBlue[indexPlayer].position, Quaternion.identity);
        }
        if (pTeam == "Red")
        {
            //PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPos, Quaternion.identity);

            GameObject instantiate = PhotonNetwork.Instantiate(charactersOrdered[0].name, spawnPointsRed[indexPlayer].position, Quaternion.identity);
        
        }
    }

    [PunRPC]
    public void RPCInstantiateCharacter(Vector3 spawnPos)
    {

        PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPos, Quaternion.identity);
    }

    public Vector3 LocalPlayerSpawnPoint => (pTeam == "Blue") ? spawnPointsBlue[indexPlayer].position : spawnPointsRed[indexPlayer].position;

}
