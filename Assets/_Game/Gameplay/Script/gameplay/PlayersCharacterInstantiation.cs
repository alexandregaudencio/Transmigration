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
        [SerializeField] private string layerNameTarget;
        public bool IsTeamA => (layerNameTarget == "TeamA") ? true : false;

        private void Start()
        {
            CharacterInstantiation();
        }

        private void CharacterInstantiation()
        {
            foreach(PlayerData playerData in playerDataStorage.PlayerList)
            {
                //Debug.Log(playerData.TeamLayer);
                if (LayerMask.LayerToName(playerData.TeamLayer) == layerNameTarget)
                {
                    Debug.Log(playerData.JoystickTeamIndex + " instantiated");

                    int indexPosition = playerData.JoystickTeamIndex ;
                    Vector3 spawnPosition = spawnPositions[indexPosition].position;
                    
                    GameObject characterObject = Instantiate(playerData.Character.CharacterPrefab,
                        spawnPosition, 
                        Quaternion.identity);

                    SetCharacterJoystick(characterObject, playerData.Joystick);
                    SetSpawnPosition(characterObject, spawnPosition);
                    //return;
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

