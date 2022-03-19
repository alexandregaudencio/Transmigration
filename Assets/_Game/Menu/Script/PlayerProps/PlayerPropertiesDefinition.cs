using Photon.Pun;
using UnityEngine;
using Photon.Pun.UtilityScripts;
using CharacterNamespace;
using System.Collections.Generic;




[RequireComponent(typeof(PhotonView))]
public class PlayerPropertiesDefinition : MonoBehaviourPunCallbacks
{

    [SerializeField] private List<GameObject> blueCharactersPrefabs;
    [SerializeField] private List<GameObject> redCharacterPrefabs;
    private PhotonView PV;

    PhotonTeam localPlayerTeam => PhotonTeamExtensions.GetPhotonTeam(PhotonNetwork.LocalPlayer);
    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();

    //public struct palavras
    //{
    //    public string soulsFreed = "SoulsFreed";
    //}

    public static PlayerPropertiesDefinition instance;
    private void Start()
    {

        instance = this;
        PV = GetComponent<PhotonView>();
    }

    private GameObject GetRandomCharacterPrefab
    {
        get
        {
            List<GameObject> targetCharacters = (localPlayerTeam.Code == 1) ?
                blueCharactersPrefabs : redCharacterPrefabs;
            return targetCharacters[Random.Range(0, targetCharacters.Count)];
        }
    }

    private CharacterProperty GetCharacterProperty(GameObject prefab)
    {
        return prefab.GetComponent<PlayerController>().CharacterProperty;
    }

    private void SetPlayerprops(CharacterProperty character)
    {
        HashProperty["HP"] = character.HP;
        HashProperty["maxHP"] = character.HP;
        HashProperty["killCount"] = 0;
        HashProperty["deathCount"] = 0;
        HashProperty["DamageTotal"] = 0;
        HashProperty["SoulsFreed"] = 0; //Quantos pontos estão sendo segurados para marcar? pontuação coletada pelo personagem antes de pontuar. Como no Pocketmon Unite
        HashProperty["SoulCollect"] = 0; //Quantos pontos foram concretizados pelo Player?
        HashProperty["timerRespawn"] = GameConfigs.instance.TimeToRespawn ;
        HashProperty["isDead"] = false;
        PhotonNetwork.LocalPlayer.SetCustomProperties(HashProperty);

    }

    private void SetPlayerTagObjct(GameObject characterPrefab)
    {
        //int playerIndex = (int)PhotonNetwork.LocalPlayer.CustomProperties["indexPlayer"];
        PhotonNetwork.LocalPlayer.TagObject = characterPrefab.name;
    }

    [PunRPC]
    public void InitializePlayer()
    {
        //aqui são definidos: propriedades globais e o personagem por cada jogador.
        GameObject character = GetRandomCharacterPrefab;
        SetPlayerprops(GetCharacterProperty(character));
        SetPlayerTagObjct(character);
    }

    public void OnClick_PVInitializePlayer()
    {
        PV.RPC("InitializePlayer", RpcTarget.All);
    }


}
