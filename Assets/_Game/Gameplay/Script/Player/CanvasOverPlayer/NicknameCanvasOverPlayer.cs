using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CanvasOverPlayerNamespace
{
    public class NicknameCanvasOverPlayer : MonoBehaviour
    {
        private TMP_Text text_nickname;

        private PhotonView PV;
        private void Awake()
        {
            text_nickname = GetComponent<TMP_Text>();
            PV = GetComponentInParent<PhotonView>();
        }

        private void Start()
        {
            text_nickname.SetText(PV.Controller.NickName);
        }
    }


}
