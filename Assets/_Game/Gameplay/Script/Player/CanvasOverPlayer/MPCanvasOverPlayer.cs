using CharacterNamespace;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasOverPlayerNamespace {
    public class MPCanvasOverPlayer : MonoBehaviour
    {
        [SerializeField] private Image image_MPFill;

        [SerializeField] private ManaManager manaManager;
        private PhotonView PV;
        private void Awake()
        {
            PV = GetComponentInParent<PhotonView>();
        }

        private void OnEnable()
        {
            manaManager.manaChange += UpdateMPCanvasOverPlayer;
        }

        private void OnDisable()
        {
            manaManager.manaChange -= UpdateMPCanvasOverPlayer;
        }

        private void Start()
        {
            UpdateMPCanvasOverPlayer();
        }

        private void UpdateMPCanvasOverPlayer()
        {
            image_MPFill.fillAmount = manaManager.ManaFraction;

        }

    }

}

