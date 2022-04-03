using CharacterNamespace;
using Managers;
using PlayerDataNamespace;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelection
{
    public class PlayerCharacterContent : MonoBehaviour
    {
        /*[SerializeField] */private int characterIndex = 0; // index do characterProperty no characters
        //[SerializeField] private RawImage rawImage_Character;
        //[SerializeField] private TMP_Text text_CharacterName;
        //[SerializeField] private TMP_Text text_CharacterClass;

        [SerializeField] private Timer timer;
        [SerializeField] private Characters characters;
        [SerializeField] private PlayerDataStorage playerDataStorage;
        [SerializeField] private LayerMask layer;
        private Animator animator;
        private InputJoystick inputJoystick;
        public CharacterProperty targetCharacter => characters.GetCharacterInList(Layer, characterIndex);

        public PlayerDataStorage PlayerDataStorage { get => playerDataStorage; set => playerDataStorage = value; }
        public LayerMask Layer { get => layer; set => layer = value; }

        public event Action<CharacterProperty> characterContentUpdate;
        public event Action<CharacterProperty> choseCharacter;
        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            inputJoystick = GetComponent<InputJoystick>();       
            
        }

        private void OnEnable()
        {
            characterContentUpdate += UpdateCharacterContent;
            timer.timeOver += choseCharacterOntimerOver;
        }
        private void OnDisable()
        {
            characterContentUpdate -= UpdateCharacterContent;
            timer.timeOver -= choseCharacterOntimerOver;

        }

        private void Start()
        {
            //APENAS para facilitar o desenvolvimento:
            playerDataStorage.ClearPlayerList();
            characterContentUpdate?.Invoke(targetCharacter);
        }

        private void Update()
        {

            if (inputJoystick.IsRigthButtonDown) GetRightCharacterInList();
            if (inputJoystick.IsLeftButtonDown)  GetLeftCharacterInList();
            if (inputJoystick.StartInputDown) choseCharacter?.Invoke(targetCharacter);
        }
        
        private void UpdateCharacterContent(CharacterProperty character)
        {
            //rawImage_Character.texture = character.SpriteIcon.texture;
            //text_CharacterName.SetText(character.CharacterName);
            //text_CharacterClass.SetText(character.CharacterClass);
            animator.Play(character.AnimationClip.name);

        }

        private void GetLeftCharacterInList()
        {
            if (characterIndex + 1 < characters.CharactersTeamA.Count) characterIndex++;
            else characterIndex = 0;
            characterContentUpdate?.Invoke(targetCharacter);

        }

        private void GetRightCharacterInList()
        {
            if (characterIndex > 0) characterIndex--;
            else characterIndex = (characters.CharactersTeamA.Count - 1);
            characterContentUpdate?.Invoke(characters.GetCharacterInList(gameObject.layer, characterIndex));
        }


        private void choseCharacterOntimerOver()
        {
            choseCharacter?.Invoke(targetCharacter);
        }

    }
}


