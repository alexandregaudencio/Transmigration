using CharacterNamespace;
using PlayerDataNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Data.Score
{



    public class UIPlayerScoreManager : MonoBehaviour
    {
        //[SerializeField] private Joystick playerIndex;
        [SerializeField] private PlayerScore playerScore;
        [SerializeField] private PlayerDataStorage playerDataStorage;
        [SerializeField] private Image iamge_characterIcon; //OK
        [SerializeField] private TMP_Text text_Damage;
        [SerializeField] private TMP_Text text_Kill;
        [SerializeField] private TMP_Text text_Death;
        [SerializeField] private TMP_Text text_Score;
        private CharacterProperty characterProperty;


        private void Start()
        {
            playerScore.damageUpdate += UpdateTextDamageUI;
            playerScore.increaseKill += UpdateTextKillUI;
            playerScore.increaseDeath += UpdateTextDeathUI;
            playerScore.scoreUpdated += UpdateTextScoreUI;

            UIManagerActive();
            iamge_characterIcon.sprite = characterProperty.SpriteIcon;
        }

        private void OnDestroy()
        {
            playerScore.damageUpdate -= UpdateTextDamageUI;
            playerScore.increaseKill -= UpdateTextKillUI;
            playerScore.increaseDeath -= UpdateTextDeathUI;
            playerScore.scoreUpdated -= UpdateTextScoreUI;


        }


        private void UIManagerActive()
        {
            characterProperty = SetCharacterPropertyTarget();
            if(characterProperty == null)
            {
                Debug.Log("Character NULL");
                gameObject.SetActive(false);
            } else
            {
                
                Debug.Log(characterProperty.name);

            }
        }

        private CharacterProperty SetCharacterPropertyTarget()
        {
            foreach (PlayerData playerData in playerDataStorage.PlayerList)
            {
                if (playerData.Joystick == playerScore.PlayerJoystick)
                    return playerData.Character;
            }
            return null;
        }


        private void UpdateTextDamageUI(float damage)
        {
            int damageAmount = (int)playerScore.DamageAmount;
            text_Damage?.SetText("Dano: "+ damageAmount.ToString());
        }
        private void UpdateTextKillUI()
        {
            text_Kill?.SetText("Derrubou: "+playerScore.KillCount.ToString());
        }
        private void UpdateTextDeathUI()
        {
            text_Death?.SetText("Perdeu: "+playerScore.DeathCount.ToString());
        }

        private void UpdateTextScoreUI(float score)
        {
            text_Score?.SetText(playerScore.score.ToString());
        }
    }


}
