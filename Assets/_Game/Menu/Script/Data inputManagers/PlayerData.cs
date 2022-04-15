using CharacterNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerDataNamespace
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private int joystickTeamIndex;
        [SerializeField] private Joystick joystick;
        [SerializeField] private string layerName;
        [SerializeField] private CharacterProperty character;

        public PlayerData(int joystickTeamIndex, Joystick joystick, string layerName, CharacterProperty character)
        {
            this.joystick = joystick;
            this.joystickTeamIndex = joystickTeamIndex;
            this.LayerName = layerName;
            this.character = character;
        }

        public int JoystickTeamIndex { get => joystickTeamIndex; set => joystickTeamIndex = value; }
        public string LayerName { get => layerName; set => layerName = value; }
        public CharacterProperty Character { get => character; set => character = value; }
        public Joystick Joystick { get => joystick; set => joystick = value; }
    }


}

