using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PlayerTeamNamespaces
{
public class PlayerPropContent : MonoBehaviourPunCallbacks
{
        [SerializeField] private TMP_Text text_Nickname;
         private PlayerTeam playerTeam;
        private void Awake()
        {
            playerTeam = GetComponent<PlayerTeam>();
        }

        public override void OnEnable()
        {
            playerTeam.InitializeContentEvent += SetNickText;
        }
        public override void OnDisable()
        {
            playerTeam.InitializeContentEvent -= SetNickText;
        }


        private void SetNickText()
        {
            text_Nickname.SetText(playerTeam.Player.NickName);

        }


    }



}
