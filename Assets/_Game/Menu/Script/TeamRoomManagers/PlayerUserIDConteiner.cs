using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//[RequireComponent(typeof(TMP_Text))]
public class PlayerUserIDConteiner : MonoBehaviourPunCallbacks
{
    //private TMP_Text text_PlayerTeamList;
    [SerializeField] private GameObject content_playerUserID;
    public List<PlayerUserIDManager> userIDManagerListing = new List<PlayerUserIDManager>();

    public event Action OnUsersIDconteinerListChanged;

    public List<PlayerUserIDManager> UserIDManagerListing { get => userIDManagerListing; set => userIDManagerListing = value; }

    public void InitializeNewPlayer(string userID)
    {
        if(TeamUserIDListContain(userID)) return;
        if (userID == "") return;
        //Instanciando o bloco do Novo uerID
        GameObject newPlayerContent = Instantiate(content_playerUserID, transform);
        //Define o userID
        PlayerUserIDManager newPlayerUserID = newPlayerContent.GetComponent<PlayerUserIDManager>();
        newPlayerUserID.SetPlayerInfo(userID);
        //Armazena o playerUserIDManager na lista
        AddPlayerToList(newPlayerUserID);

    }

    public void AddPlayerToList(PlayerUserIDManager playerManager)
    {
        userIDManagerListing.Add(playerManager);
        OnUsersIDconteinerListChanged?.Invoke();

    }
    public void RemovePlayerAtList(PlayerUserIDManager playerManager)
    {
        userIDManagerListing.Remove(playerManager);
        OnUsersIDconteinerListChanged?.Invoke();

    }

    public bool TeamUserIDListContain(string userID)
    {
        foreach (PlayerUserIDManager userIDManager in userIDManagerListing)
        {
            if (userIDManager.PlayerUserID == userID)
            {
                return true;
            }
        }
        return false;


    }

    public new void OnEnable()
    {
        if(PhotonNetwork.LocalPlayer.UserId != "")
        InitializeNewPlayer(PhotonNetwork.AuthValues.UserId);

    }

    public new void OnDisable()
    {
        ResetConteiner();
    }

    private void ResetConteiner()
    {
        userIDManagerListing.Clear();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);

        }
    }



}
