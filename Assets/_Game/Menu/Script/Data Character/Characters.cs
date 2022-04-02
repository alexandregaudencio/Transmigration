using CharacterNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSelection
{
    [CreateAssetMenu(fileName ="characters",menuName ="characterList")]
    public class Characters : ScriptableObject
    {
        [SerializeField] private List<CharacterProperty> charactersTeamA;
        [SerializeField] private List<CharacterProperty> charactersTeamB;

        public List<CharacterProperty> CharactersTeamA { get => charactersTeamA; set => charactersTeamA = value; }
        public List<CharacterProperty> CharactersTeamB { get => charactersTeamB; set => charactersTeamB = value; }

        public CharacterProperty GetCharacterInList(LayerMask layer, int index)
        {
            return (layer == LayerMask.NameToLayer("TeamA")) ? charactersTeamA[index] : charactersTeamB[index];
        }


    }

}
