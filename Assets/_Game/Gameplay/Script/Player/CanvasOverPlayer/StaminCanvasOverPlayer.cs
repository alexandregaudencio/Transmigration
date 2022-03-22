using CharacterNamespace;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasOverPlayerNamespace
{
    public class StaminCanvasOverPlayer : MonoBehaviour
    {
         [SerializeField] private Image image_StaminFill;
        private PhotonView PV;

        [SerializeField] private DashManager dashManager;

        private void OnEnable()
        {
            dashManager.staminChangesAction += UpdateStaminCanvasOverPlayer;
        }
        private void OnDisable()
        {
            dashManager.staminChangesAction -= UpdateStaminCanvasOverPlayer;

        }

        private void Awake()
        {
            //if (!PV.IsMine) gameObject.SetActive(false);
            PV = GetComponentInParent<PhotonView>();
            //image_StaminFill = GetComponentInChildren<Image>();

        }

        private void Start()
        {
            UpdateStaminCanvasOverPlayer();
        }

        private void UpdateStaminCanvasOverPlayer()
        {
            image_StaminFill.fillAmount = dashManager.DashStaminFraction;

        }

    }

}
