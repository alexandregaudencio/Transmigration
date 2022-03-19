﻿using Photon.Pun;
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
            return blueCharactersPrefabs[Random.Range(0, targetCharacters.Count)];
        }
    }

    private CharacterProperty GetCharacterProperty(GameObject prefab)
    {
        return prefab.GetComponent<PlayerController>().CharacterProperty;
    }

    private void SetPlayerprops(CharacterProperty character)
    {
        HashProperty["killCount"] = 0;
        HashProperty["deathCount"] = 0;
        HashProperty["DamageAmount"] = 0;

        HashProperty["HP"] = character.HP;
        HashProperty["maxHP"] = character.HP;

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
        //aqui é definido: propriedades globais e o personagem por cada jogador.
        GameObject character = GetRandomCharacterPrefab;
        SetPlayerprops(GetCharacterProperty(character));
        SetPlayerTagObjct(character);
    }

    public void OnClick_PVInitializePlayer()
    {
        PV.RPC("InitializePlayer", RpcTarget.All);
    }


}
