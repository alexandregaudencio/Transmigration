using CharacterNamespace;
using PlayerDataNamespace;
using UnityEngine;

namespace CharacterSelection
{
    [RequireComponent(typeof(PlayerCharacterContent))]
    [RequireComponent(typeof(InputJoystick))]

    public class DefineCharacter : MonoBehaviour
    {
        private PlayerCharacterContent playerCharacterContent;
        private InputJoystick inputJoystick;

        private void Awake()
        {
            playerCharacterContent = GetComponent<PlayerCharacterContent>();
            inputJoystick = GetComponent<InputJoystick>();
        }

        private void OnEnable()
        {
            playerCharacterContent.choseCharacter += SetPlayerData;
        }
        
        private void OnDisable()
        {
            playerCharacterContent.choseCharacter -= SetPlayerData;

        }

        private void SetPlayerData(CharacterProperty character)
        {
            int joystickIndex;
            if (inputJoystick.JoystickTeamIndex.TryGetValue(inputJoystick.Joystick, out joystickIndex)) { 
                PlayerData playerData = new PlayerData( 
                    joystickIndex,
                    inputJoystick.Joystick,
                    playerCharacterContent.LayerName,
                    character);
                playerCharacterContent.PlayerDataStorage.AddPlayerToList(playerData);
                Debug.Log(playerData.Character.name);
            }
        }

    }




}
