using CharacterNamespace;
using CharacterSelection;
using Managers;
using PlayerDataNamespace;
using System.Collections;
using System.Collections.Generic;
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
            PlayerData playerData = new PlayerData(
                inputJoystick.Joystick,
                playerCharacterContent.Layer,
                character);
            playerCharacterContent.PlayerDataStorage.AddPlayerToList(playerData);

        }


    }

}

