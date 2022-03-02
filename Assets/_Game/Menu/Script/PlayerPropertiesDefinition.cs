using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerPropertiesDefinition : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject[] charactersPrefab;

    //PhotonView PV;

    public static PlayerPropertiesDefinition instance;

    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();

    private void Start()
    {
        instance = this;
    }

    void SetPlayerprops()
    {
        HashProperty["HP"] = GameConfigs.instance.HP;
        HashProperty["maxHP"] = GameConfigs.instance.HP;
        HashProperty["killCount"] = 0;
        HashProperty["deathCount"] = 0;
        HashProperty["timerRespawn"] = GameConfigs.instance.timeToRespawn ;
        HashProperty["isDead"] = false;
        PhotonNetwork.LocalPlayer.SetCustomProperties(HashProperty);

    }

    void SetPlayerCharacter()
    {
        int playerIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        PhotonNetwork.LocalPlayer.TagObject = charactersPrefab[0].name;
    }

    //[PunRPC]
    public void SetCharacterAndProps()
    {        
        //aqui é definido a escolha do personagem do jogador e as propriedades dele.

        SetPlayerprops();
        SetPlayerCharacter();
    }



}
