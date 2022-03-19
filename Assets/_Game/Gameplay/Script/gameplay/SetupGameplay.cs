using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGameplay : MonoBehaviour
{
    private PhotonView PV;

    [SerializeField] private Transform[] spawnPointsBlue, spawnPointsRed;
    //[SerializeField] private GameObject[] charactersOrdered;
    private int indexPlayer = 1;
    PhotonTeam playerLocalTeam => PhotonNetwork.LocalPlayer.GetPhotonTeam();
    private GameObject localCamera;
    public static SetupGameplay instance;
    
    void Start()
    {
        instance = this;

        //indexPlayer = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        InstantiatingPlayersCharacter();
        //text.text = "IndexPlayer: " + indexPlayer + " " + PhotonNetwork.LocalPlayer.TagObject.ToString();
        
        //PhotonNetwork.Instantiate("PlayerA", spawnPointsBlue[indexPlayer].position, Quaternion.identity);

    }

   

    private void InstantiatingPlayersCharacter()
    {

        //int indexPlayer = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        //string pTeam = PhotonNetwork.LocalPlayer.GetPhotonTeam().Name;

        //TODO: trocar o index de charactersOrdered pelo personagem escolhido
        if (playerLocalTeam.Code == 1)
        {
            //PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPos, Quaternion.identity);

            PhotonNetwork.Instantiate(
                PhotonNetwork.LocalPlayer.TagObject.ToString(),
                LocalPlayerSpawnPoint, 
                Quaternion.identity);
            return;
        }
        
        PhotonNetwork.Instantiate(
            PhotonNetwork.LocalPlayer.TagObject.ToString(),
            LocalPlayerSpawnPoint, 
            Quaternion.identity); ;
        
        
    }

    //[PunRPC]
    //public void RPCInstantiateCharacter(Vector3 spawnPos)
    //{

    //    PhotonNetwork.Instantiate(PhotonNetwork.LocalPlayer.TagObject.ToString(), spawnPos, Quaternion.identity);
    //}

    public Vector3 LocalPlayerSpawnPoint => (playerLocalTeam.Code == 1) ? 
        spawnPointsBlue[indexPlayer].position : spawnPointsRed[indexPlayer].position;

}
