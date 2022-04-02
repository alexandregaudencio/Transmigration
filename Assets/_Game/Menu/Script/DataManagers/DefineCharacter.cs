using CharacterNamespace;
using CharacterSelection;
using Managers;
using PlayerData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSelection
{
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
            playerCharacterContent.choseCharacter += SetCharacterPref;
        }

        private void OnDisable()
        {
            playerCharacterContent.choseCharacter -= SetCharacterPref;

        }

        private void SetCharacterPref(int characterIndex)
        {
            PlayerPrefs.SetInt("Player"+inputJoystick.Joystick, characterIndex);
            Debug.Log(PlayerPrefs.GetInt("Player" + inputJoystick.Joystick));
        }


    }

}

