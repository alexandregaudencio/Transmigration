using Photon.Pun;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();


    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    public override void OnConnectedToMaster()
    {
        if(!PhotonNetwork.InLobby) PhotonNetwork.JoinLobby();
    }



}
