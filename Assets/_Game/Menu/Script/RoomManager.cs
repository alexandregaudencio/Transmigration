using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Collections;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TeamManager teamManager;
    [SerializeField] private Text playerCountText;

    private PlayerPropertiesDefinition playerPropertiesDefinition;


    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        playerPropertiesDefinition = GetComponent<PlayerPropertiesDefinition>();
    }


    private void Update()
    {

        //PARA TESTES
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (PhotonNetwork.IsMasterClient)
            {
                StartCoroutine(transitionToCharactSelectScene());
            }
        }

    }

    //AÇÃO BOTÃO START
    public void StartMatchmaking()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    //AÇÃO BOTAO BACK
    public void StopMatchmaking()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string roomName = Random.Range(0, 2000).ToString();
        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = (byte)GameConfigs.instance.maxRoomPlayers,
            IsOpen = true
        };
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }


    public override void OnJoinedRoom()
    {
        teamManager.TeamDefinition(PhotonNetwork.LocalPlayer);
        UpdatePlayercountText();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayercountText();

        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                StartCoroutine(transitionToCharactSelectScene());
            }
        }

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayercountText();
    }


    IEnumerator transitionToCharactSelectScene()
    {
        playerPropertiesDefinition.SetCharacter();
        yield return new WaitForSeconds(1);
        PhotonNetwork.LoadLevel(GameConfigs.instance.gameplaySceneIndex);

    }

    private void UpdatePlayercountText()
    {
        playerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount + " de " + PhotonNetwork.CurrentRoom.MaxPlayers;
    }




}
