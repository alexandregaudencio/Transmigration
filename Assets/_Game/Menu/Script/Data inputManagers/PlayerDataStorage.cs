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
                if(p.JoystickTeamIndex == newPlayerData.JoystickTeamIndex)
                {
                    Debug.Log("Update PlayerData " + p.JoystickTeamIndex);
                    p.Character = newPlayerData.Character;
                    p.TeamLayer = newPlayerData.TeamLayer;
                    return;
                }
            }
            playerList.Add(newPlayerData);
            Debug.Log("new PlayerData " + newPlayerData.JoystickTeamIndex);
            Debug.Log("new CharacterProperty " + newPlayerData.Character.name);

        }

        public void ClearPlayerList()
        {
            playerList.Clear();
        }
    }
}
