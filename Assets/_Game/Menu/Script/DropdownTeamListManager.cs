using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class DropdownTeamListManager : MonoBehaviourPunCallbacks
{
    private TMP_Dropdown dropdown;
    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        dropdown.ClearOptions();
        List<string> dropdownItensList = new List<string>(){ "Random" };

        foreach (RoomInfo room in roomList)
        {
            dropdownItensList.Add(room.Name);
        }

        dropdown.AddOptions(dropdownItensList);
    }


}
