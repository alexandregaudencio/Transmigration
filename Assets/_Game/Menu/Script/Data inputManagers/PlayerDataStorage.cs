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
                    //Debug.Log("Update PlayerData " + p.JoystickTeamIndex);
                    p.JoystickTeamIndex = newPlayerData.JoystickTeamIndex;
                    p.Character = newPlayerData.Character;
                    p.LayerName = newPlayerData.LayerName;
                    Debug.Log("update: " + newPlayerData.Joystick);

                    return;
                }
            }
            playerList.Add(newPlayerData);
            Debug.Log("Storage: " + newPlayerData.Joystick);

            //Debug.Log("new PlayerData " + newPlayerData.JoystickTeamIndex);
            //Debug.Log("new CharacterProperty " + newPlayerData.Character.name);

        }

        public void ClearPlayerList()
        {
            playerList.Clear();
        }
    }
}
