using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Ajustar esta pasta
public class StartMatchmaking : MonoBehaviourPunCallbacks
{
     [SerializeField] private GameObject button_Start;
    //[SerializeField] private PlayerPropertiesDefinition playerPropertiesDefinition;

    private void Start()
    {
        button_Start?.SetActive(false);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        ActiveGameObjectAtRoomFull(button_Start);
    }



    //quando o btão de start game é apertado
    public void OnClick_StartMatchMaking()
    {
        //deve ser feito pelo MASTERCLIENT e quando ta lotado e quando não ta lotado.
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        StartCoroutine(waitToStart());
    }

    IEnumerator waitToStart()
    {
        //GetComponent<PhotonView>().RPC("SetProps", RpcTarget.All);

        yield return new WaitForSeconds(1);
        PhotonNetwork.LoadLevel(GameConfigs.instance.gameplaySceneIndex);

    }


    //cada player deve definir suas propriedades, personagens e etc.
    //[PunRPC]
    //public void SetProps()
    //{
    //    playerPropertiesDefinition.SetCharacterAndProps();

    //}


    //mostra o botão START GAME para o masterClient
    public void ActiveGameObjectAtRoomFull(GameObject gameObject)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            byte playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            byte maxPlayers = PhotonNetwork.CurrentRoom.MaxPlayers;
            button_Start?.SetActive((playerCount == maxPlayers) ? true : false);
        }

    }
}
