using CharacterNamespace;
using Managers;
using PlayerDataNamespace;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CharacterSelection
{
    public class PlayerCharacterContent : MonoBehaviour
    {

        [SerializeField] public int characterIndex = 0; // index do characterProperty no characters
        [SerializeField] private Timer timer;
        [SerializeField] private Characters characters;
        [SerializeField] private PlayerDataStorage playerDataStorage;
        [SerializeField] private string layerName;
        [SerializeField] private UnityEvent ChoseCharacter;
        private AudioManager audioManager;
        private bool isCharacterChoosed = false;
        /*[SerializeField] */
        private Animator animator;
        private InputJoystick inputJoystick;
        public CharacterProperty targetCharacter => targetCharacterList[characterIndex];
        public PlayerDataStorage PlayerDataStorage { get => playerDataStorage; set => playerDataStorage = value; }
        public string LayerName { get => layerName; set => layerName = value; }
        public List<CharacterProperty> targetCharacterList => (layerName == "TeamA") ? 
            characters.CharactersTeamA : characters.CharactersTeamB;
        
        public event Action<CharacterProperty> characterContentUpdate;
        public event Action<CharacterProperty> choseCharacter;
        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            inputJoystick = GetComponent<InputJoystick>();
            audioManager = GetComponent<AudioManager>();
        }

        private void OnEnable()
        {
            characterContentUpdate += UpdateCharacterContent;
            //timer.timeOver += choseCharacterOntimerOver;
        }
        private void OnDisable()
        {
            characterContentUpdate -= UpdateCharacterContent;
            //timer.timeOver -= choseCharacterOntimerOver;
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
            if (inputJoystick.IsLeftButtonDown) GetLeftCharacterInList();
            if (inputJoystick.StartInputDown)
            {
                //Debug.Log(inputJoystick.Joystick + " Escolheu:" + targetCharacter);
                choseCharacter?.Invoke(targetCharacter);
                ChoseCharacter?.Invoke();
                //isCharacterChoosed = true;
                //characterContentUpdate?.Invoke(targetCharacter);

            }

        }
        
        private void UpdateCharacterContent(CharacterProperty character)
        {
            //rawImage_Character.texture = character.SpriteIcon.texture;
            //text_CharacterName.SetText(character.CharacterName);
            //text_CharacterClass.SetText(character.CharacterClass);
            animator?.Play(character.AnimationClip.name);
            audioManager.PlayAudioClip();

        }

        private void GetLeftCharacterInList()
        {
            if (characterIndex > 0) characterIndex--;
            else characterIndex = (targetCharacterList.Count - 1);
            characterContentUpdate?.Invoke(targetCharacter);

        }

        private void GetRightCharacterInList()
        {
            if (characterIndex + 1 < targetCharacterList.Count) characterIndex++;
            else characterIndex = 0;
            characterContentUpdate?.Invoke(targetCharacter);


        }

        //private void choseCharacterOntimerOver()
        //{
        //    if(inputJoystick.enabled)
        //        choseCharacter?.Invoke(targetCharacter);
        //}

    }
}


