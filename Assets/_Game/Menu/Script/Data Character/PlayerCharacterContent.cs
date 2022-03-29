using CharacterNamespace;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelection
{
    public class PlayerCharacterContent : MonoBehaviour
    {
        //[SerializeField] private int playerIndex;
        [SerializeField] [Min(0)] private int characterIndex;
        [SerializeField] private RawImage rawImage_Character;
        [SerializeField] private TMP_Text text_CharacterName;
        [SerializeField] private TMP_Text text_CharacterClass;
        private Characters characters;
        private CharacterProperty targetCharacter;
        public event Action<CharacterProperty> characterContentUpdateEvent;

        private void Awake()
        {
            characters = GetComponentInParent<Characters>();
        }

        private void OnEnable()
        {
            characterContentUpdateEvent += UpdateCharacterContent;
        }
        private void OnDisable()
        {
            characterContentUpdateEvent -= UpdateCharacterContent;
        }

        private void Start()
        {
            characterContentUpdateEvent?.Invoke(characters.CharacterTarget(characterIndex));


        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (characterIndex > 0) characterIndex--;
                else characterIndex = (characters.CharactersList.Count-1);
                characterContentUpdateEvent?.Invoke(characters.CharacterTarget(characterIndex));

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (characterIndex+1 < characters.CharactersList.Count) characterIndex++;
                else characterIndex = 0;
                characterContentUpdateEvent?.Invoke(characters.CharacterTarget(characterIndex));
            }
        }

        //public void ChooseCharacter(CharacterProperty character)
        //{
        //    targetCharacter = characters.CharactersList[characterIndex];
        //    characterContentUpdateEvent?.Invoke(character);
        //}

        public void UpdateCharacterContent(CharacterProperty character)
        {
            rawImage_Character.texture = character.SpriteIcon.texture;
            text_CharacterName.SetText(character.CharacterName);
            text_CharacterClass.SetText(character.CharacterClass);

        }

    }
}


