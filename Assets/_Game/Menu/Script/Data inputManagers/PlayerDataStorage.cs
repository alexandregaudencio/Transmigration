using System.Collections.Generic;
using UnityEngine;

namespace PlayerDataNamespace
{
    [CreateAssetMenu(fileName = "PlayerDataStorage", menuName = "PlayerDataStorage")]
    public class PlayerDataStorage : ScriptableObject
    {
        [SerializeField] private List<PlayerData> PlayerList;

        public List<PlayerData> PlayerList1 { get => PlayerList; set => PlayerList = value; }

        public void AddPlayerToList(PlayerData newPlayerData)
        {
            foreach(PlayerData p in PlayerList)
            {
                if(p.Joystick == newPlayerData.Joystick)
                {
                    Debug.Log("Update PlayerData " + p.Joystick);
                    p.Character = newPlayerData.Character;
                    p.TeamLayer = newPlayerData.TeamLayer;
                    return;
                }
            }
            PlayerList.Add(newPlayerData);
            Debug.Log("new PlayerData " + newPlayerData.Joystick);

        }

        public void ClearPlayerList()
        {
            PlayerList.Clear();
        }
    }
}
