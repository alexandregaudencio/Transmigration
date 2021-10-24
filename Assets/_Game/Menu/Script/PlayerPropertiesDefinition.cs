using Photon.Pun;
using UnityEngine;

public class PlayerPropertiesDefinition : MonoBehaviour
{

    [SerializeField] private GameObject[] charactersPrefab;


    public static PlayerPropertiesDefinition instance;

    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();


    //// Start is called before the first frame update
    //void Start()
    //{
    //    //PhotonNetwork.LocalPlayer.TagObject = charactersPrefab[0].name;
    //    //SetPlayerprops();
    //}
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

    public void SetCharacter()
    {
        SetPlayerprops();

        int playerIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        PhotonNetwork.LocalPlayer.TagObject = charactersPrefab[playerIndex].name;
    }


}
