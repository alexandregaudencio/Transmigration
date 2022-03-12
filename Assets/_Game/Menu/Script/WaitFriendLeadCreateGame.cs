using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using System;

public class WaitFriendLeadCreateGame : MonoBehaviourPunCallbacks
{
    //private TMP_InputField inputField_LeadName;

    //public string leaderUserId = "";

    //private LoadBalancingClient loadBalancingClient;

    ////private new void OnEnable()
    ////{
    ////    StartCoroutine(WaitLeadCreateRoom());
    ////}

    ////private new void OnDisable()
    ////{
    ////    StopCoroutine(WaitLeadCreateRoom());

    ////}

    //private void Start()
    //{
    //    inputField_LeadName = GetComponentInChildren<TMP_InputField>();

    //    inputField_LeadName.onValueChanged.AddListener(delegate
    //    {
    //        leaderUserId = inputField_LeadName.text;
    //        //loadBalancingClient.OpFindFriends(new string[1] { leaderUserId });
    //        StopAllCoroutines();
    //        StartCoroutine(FindLeader());


    //    });
    //}


    //public override void OnFriendListUpdate(List<FriendInfo> friendList)
    //{
    //    base.OnFriendListUpdate(friendList);

    //    foreach (FriendInfo info in friendList)
    //    {
    //        if(info.IsInRoom && info.IsOnline)
    //        {
    //            PhotonNetwork.JoinRoom(info.Room);
    //        }

    //    }
    //}


    //private IEnumerator FindLeader()
    //{
    //    while (true)
    //    { 
    //        if(PhotonNetwork.FindFriends(new string[1] { leaderUserId }))
    //        {
    //            PhotonNetwork.FindFriends(new string[1] { leaderUserId });
    //        }

    //        yield return new WaitForSeconds(0.5f);
    //    }

    //}
}

