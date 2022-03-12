using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddUserID : MonoBehaviourPunCallbacks
{
    //[SerializeField]  private GameObject button_AddPlayer;
    //[SerializeField] private PlayerUserIDConteiner playerUserIDConteiner;

    //private TMP_InputField inputField_AddPlayer;


    //private void Awake()
    //{
    //    playerUserIDConteiner = GetComponentInChildren<PlayerUserIDConteiner>();
    //    inputField_AddPlayer = GetComponentInChildren<TMP_InputField>();

    //}
    //public void OnClick_FindFrindUserID()
    //{
    //    string userID = inputField_AddPlayer?.text;
    //    if(userID != "")
    //    {
    //        PhotonNetwork.FindFriends(new string[] { userID });
    //    }
    //}


    //public override void OnFriendListUpdate(List<FriendInfo> friendList)
    //{
    //    base.OnFriendListUpdate(friendList);
    //    foreach(FriendInfo info in friendList)
    //    {
    //        bool isTeamNotFull = (playerUserIDConteiner.UserIDManagerListing.Count < GameConfigs.instance.maxTeamPlayers);
    //        if(isTeamNotFull)
    //        {
    //            if (info.IsOnline)
    //            {
    //                Debug.Log("O " + info.UserId + " está online?: " + info.IsOnline);
    //                playerUserIDConteiner.InitializeNewPlayer(info.UserId);
    //            }
    //            else
    //            {
    //                Debug.Log(info.UserId + " is offline");
    //            }
    //        } else
    //        {
    //            Debug.Log("Time cheio");
    //        }
            

    //    }

    //    inputField_AddPlayer.text = "";
    //}
}
