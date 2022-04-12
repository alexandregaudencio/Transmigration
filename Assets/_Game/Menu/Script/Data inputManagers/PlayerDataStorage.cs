using System.Collections.Generic;
using UnityEngine;

namespace PlayerDataNamespace
{
    [CreateAssetMenu(fileName = "PlayerDataStorage", menuName = "PlayerDataStorage")]
    public class PlayerDataStorage : ScriptableObject
    {
        [SerializeField] private List<PlayerData> playerList;

        public List<PlayerData> PlayerList { get => playerList; set => playerList = value; }

        public void AddPlayerToList(PlayerData newPlayerData)
        {
            foreach(PlayerData p in playerList)
            {
                if(p.Joystick == newPlayerData.Joystick)
                {
                    Debug.Log("Update PlayerData " + p.Joystick);
                    p.Character = newPlayerData.Character;
                    p.TeamLayer = newPlayerData.TeamLayer;
                    return;
                }
            }
            playerList.Add(newPlayerData);
            Debug.Log("new PlayerData " + newPlayerData.Joystick);
            Debug.Log("new CharacterProperty " + newPlayerData.Character.name);

        }

        public void ClearPlayerList()
        {
            playerList.Clear();
        }
    }
}
