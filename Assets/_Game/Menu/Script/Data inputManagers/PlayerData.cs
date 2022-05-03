using CharacterNamespace;
using Player.Data.Score;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerDataNamespace
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private int characterIndexOnTeam;
        [SerializeField] private Joystick joystick;
        [SerializeField] private string layerName;
        [SerializeField] private CharacterProperty character;
        [SerializeField] private PlayerScore playerScore;

        public PlayerData(int joystickTeamIndex, Joystick joystick, string layerName, CharacterProperty character)
        {
            this.joystick = joystick;
            this.characterIndexOnTeam = joystickTeamIndex;
            this.LayerName = layerName;
            this.character = character;
        }

        public int JoystickTeamIndex { get => characterIndexOnTeam; set => characterIndexOnTeam = value; }
        public string LayerName { get => layerName; set => layerName = value; }
        public CharacterProperty Character { get => character; set => character = value; }
        public Joystick Joystick { get => joystick; set => joystick = value; }
    }


}

