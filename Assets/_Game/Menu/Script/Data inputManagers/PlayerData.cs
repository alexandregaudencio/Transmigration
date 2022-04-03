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
        [Range(1, 6)] private Joystick joystick;
        private LayerMask teamLayer;
        private CharacterProperty character;

        public PlayerData(Joystick joystick, LayerMask teamLayer, CharacterProperty character)
        {
            this.joystick = joystick;
            this.teamLayer = teamLayer;
            this.character = character;
        }

        public Joystick Joystick { get => joystick; set => joystick = value; }
        public LayerMask TeamLayer { get => teamLayer; set => teamLayer = value; }
        public CharacterProperty Character { get => character; set => character = value; }
    }


}

