using CharacterNamespace;
using PlayerData;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelection
{
    public class PlayerCharacterContent : MonoBehaviour
    {
        //[SerializeField] private int playerIndex;
        [SerializeField]  private int playerIndex;
        [SerializeField] private RawImage rawImage_Character;
        [SerializeField] private TMP_Text text_CharacterName;
        [SerializeField] private TMP_Text text_CharacterClass;
        private Characters characters;
        private CharacterProperty targetCharacter;
        private InputJoystick inputJoystick;

        public event Action<CharacterProperty> characterContentUpdateEvent;

        private void Awake()
        {
            inputJoystick = GetComponent<InputJoystick>();
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
            characterContentUpdateEvent?.Invoke(characters.CharacterTarget(playerIndex));


        }

        private void Update()
        {

            if (inputJoystick.IsRigthButtonDown )
            {
                if (playerIndex > 0) playerIndex--;
                else playerIndex = (characters.CharactersList.Count - 1);
                characterContentUpdateEvent?.Invoke(characters.CharacterTarget(playerIndex));

            }
            if (inputJoystick.IsLeftButtonDown)
            {
                if (playerIndex + 1 < characters.CharactersList.Count) playerIndex++;
                else playerIndex = 0;
                characterContentUpdateEvent?.Invoke(characters.CharacterTarget(playerIndex));
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


