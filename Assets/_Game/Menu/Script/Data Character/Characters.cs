using CharacterNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSelection
{
    public class Characters : MonoBehaviour
    {
        [SerializeField] private List<CharacterProperty> charactersList;
        public List<CharacterProperty> CharactersList { get => charactersList; set => charactersList = value; }

        public CharacterProperty CharacterTarget(int index)
        {
            return charactersList[index];
        }
        //public void RemoveCharacterInList(int index)
        //{
        //    charactersList.Remove(CharacterTarget(index));
        //}

        //public void InserCharacterInList(CharacterProperty character)
        //{
        //    charactersList.Add(character);
        //}

        //public CharacterProperty NextCharacter(int indexActual)
        //{
        //    if (indexActual < charactersList.Count)
        //    {
        //        return CharacterTarget(indexActual + 1);
        //    }
        //    else
        //    {
        //        return CharacterTarget(0);

        //    }

        //}
        //public CharacterProperty BeforeCharacter(int indexActual)
        //{
        //    if (indexActual > 0)
        //    {
        //        return CharacterTarget(indexActual - 1);
        //    }else
        //    {
        //        return CharacterTarget(charactersList.Count);

        //    }

        //}

    }

}
