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
        }

        private void CharacterInstantiation()
        {
            foreach(PlayerData playerData in playerDataStorage.PlayerList)
            {
                if (playerData.TeamLayer == layerTarget)
                {
                    int indexPosition = (int)playerData.Joystick + spawPositionAdjustForTeamB;
                    Vector3 spawnPosition = spawnPositions[indexPosition].position;
                    
                    GameObject characterObject = Instantiate(playerData.Character.CharacterPrefab,
                        spawnPosition, 
                        Quaternion.identity);
                    Debug.Log(characterObject.name + " instanciated");

                    SetCharacterJoystick(characterObject, playerData.Joystick);
                    SetSpawnPosition(characterObject, spawnPosition);
                    return;
                }
            }

        }
        

        private void SetCharacterJoystick(GameObject characterObject,Joystick joystick)
        {
            InputJoystick inputJoystick = characterObject.GetComponent<InputJoystick>();
            inputJoystick.Joystick = joystick;
        }

        private void SetSpawnPosition(GameObject characterObject, Vector3 spawnPosition )
        {
            PlayerController playerController = characterObject.GetComponent<PlayerController>();
            playerController.SpawnPosition = spawnPosition;
        }



    }
}

