using CharacterNamespace;
using CharacterSelection;
using PlayerDataNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PlayersCharacterInstantiation : MonoBehaviour
    {
        [SerializeField] private Characters characters;
        [SerializeField] private PlayerDataStorage playerDataStorage;
        [SerializeField] private List<Transform> spawnPositions;
        [SerializeField] private LayerMask layerTarget;
        public string LayerName => LayerMask.LayerToName(layerTarget);
        public bool IsTeamA => (LayerName == "TeamA") ? true : false;
        public int spawPositionAdjustForTeamB => !IsTeamA ? 0 : -3;
        private void Start()
        {
            CharacterInstantiation();
            //if (IsATeamALayer)
            //{
            //    CharacterInstantiation(characters.CharactersTeamA);
            //    Debug.Log("Tem alguem do time A");
            //}
            //else
            //{
            //    Debug.Log("Tem alguem do time B");

            //    CharacterInstantiation(characters.CharactersTeamB);
            //}
        }




        private void CharacterInstantiation()
        {
            foreach(PlayerData playerData in playerDataStorage.PlayerList1)
            {
                if (playerData.TeamLayer == layerTarget)
                {
                    int indexPosition = (int)playerData.Joystick + spawPositionAdjustForTeamB;
                    GameObject character = Instantiate(playerData.Character.CharacterPrefab,
                        spawnPositions[indexPosition].position, 
                        Quaternion.identity);
                    SetCharacterJoystick(character, playerData.Joystick);
                }
            }

        }


        private void SetCharacterJoystick(GameObject character,Joystick joystick)
        {
            InputJoystick inputJoystick = character.GetComponent<InputJoystick>();
            inputJoystick.Joystick = joystick;
        }



    }
}

