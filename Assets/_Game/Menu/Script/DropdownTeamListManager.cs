
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;


public class DropdownTeamListManager : MonoBehaviourPunCallbacks
{
    private TMP_Dropdown dropdown;
    List<string> dropdownItensList = new List<string>() { "RANDOM" };

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }


    //não exibe uma lista. so lista as salas que foram criadas em uma mesma instânica

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        dropdown.ClearOptions();
        UpdateItemList(roomList);
        dropdown.AddOptions(dropdownItensList);
    }


    private void UpdateItemList(List<RoomInfo> newRoomList)
    {

        foreach (RoomInfo room in newRoomList)
        {
            if (dropdownItensList.Contains(room.Name))
            {
                dropdownItensList.Remove(room.Name);
            }
            else
            {
                dropdownItensList.Add(room.Name);
            }
        }

    }

}
