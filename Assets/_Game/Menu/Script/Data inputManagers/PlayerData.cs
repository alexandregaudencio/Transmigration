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
        [Range(1, 6)] private int joystickTeamIndex;
        [Range(1, 6)] private Joystick joystick;
        private LayerMask teamLayer;
        private CharacterProperty character;

        public PlayerData(int joystickTeamIndex, Joystick joystick, LayerMask teamLayer, CharacterProperty character)
        {
            this.joystick = joystick;
            this.joystickTeamIndex = joystickTeamIndex;
            this.teamLayer = teamLayer;
            this.character = character;
        }

        public int JoystickTeamIndex { get => joystickTeamIndex; set => joystickTeamIndex = value; }
        public LayerMask TeamLayer { get => teamLayer; set => teamLayer = value; }
        public CharacterProperty Character { get => character; set => character = value; }
        public Joystick Joystick { get => joystick; set => joystick = value; }
    }


}

