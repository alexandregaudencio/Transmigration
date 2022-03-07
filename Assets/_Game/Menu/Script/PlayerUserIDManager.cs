using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//[Serializable]
public class PlayerUserIDManager : MonoBehaviour
{

    public  string playerUserID;
    private TMP_Text text_playerUserID;
    [SerializeField] private GameObject button_playerUserIDRemove;

    public string PlayerUserID { get => playerUserID; set => playerUserID = value; }

    private void Awake()
    {
        text_playerUserID = GetComponentInChildren<TMP_Text>();
        //button_playerUserIDRemove.SetActive(false);
    }

    private void OnEnable()
    {
        button_playerUserIDRemove.GetComponent<Button>().onClick.AddListener(delegate
        {
            //RemovePlayer da lista
            RemoveUserID();
        });
    }

    public void SetPlayerInfo(string userID)
    {
        this.playerUserID = userID;
        text_playerUserID.text = userID;
        button_playerUserIDRemove.SetActive(IsNotLocalUserID(userID)); 
    }

    private void RemoveUserID()
    {
        PlayerUserIDConteiner conteiner = GetComponentInParent<PlayerUserIDConteiner>();
        conteiner.RemovePlayerAtList(this);
        Destroy(gameObject);
    }

    private bool IsNotLocalUserID(string userID)
    {
        return (userID != PhotonNetwork.LocalPlayer.UserId);
    }

}
