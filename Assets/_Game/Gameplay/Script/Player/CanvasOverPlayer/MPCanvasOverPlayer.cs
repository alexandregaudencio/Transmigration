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
        private PhotonView PV;

        [SerializeField] private ManaManager manaManager;

        private void Awake()
        {
            PV = GetComponentInParent<PhotonView>();
        }

        private void OnEnable()
        {
            manaManager.manaChangesAction += UpdateMPCanvasOverPlayer;
        }

        private void OnDisable()
        {
            manaManager.manaChangesAction -= UpdateMPCanvasOverPlayer;
        }

        private void Start()
        {
            //if (!PV.IsMine) gameObject.SetActive(false);
            UpdateMPCanvasOverPlayer();
        }

        private void UpdateMPCanvasOverPlayer()
        {
            image_MPFill.fillAmount = manaManager.ManaFraction;

        }

    }

}

