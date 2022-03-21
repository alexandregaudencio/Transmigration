using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasOverPlayerNamespace
{
    public class StaminCanvasOverPlayer : MonoBehaviour
    {
        private Image image_MPFill;
        private PhotonView PV;

        public float MPFraction
        {
            get
            {
                return 0;
            }
        }

        private void OnEnable()
        {

        }
        private void OnDisable()
        {
            
        }

        private void Awake()
        {
            //if (!PV.IsMine) gameObject.SetActive(false);
            PV = GetComponentInParent<PhotonView>();
        }

        private void Start()
        {
            UpdateStaminCanvasOverPlayer();
        }

        private void UpdateStaminCanvasOverPlayer()
        {
            image_MPFill.fillAmount = MPFraction;

        }

    }

}
