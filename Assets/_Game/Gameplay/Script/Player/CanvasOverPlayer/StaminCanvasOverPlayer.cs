using CharacterNamespace;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasOverPlayerNamespace
{
    public class StaminCanvasOverPlayer : MonoBehaviour
    {
        [SerializeField] private Image image_StaminFill;
        [SerializeField] private DashManager dashManager;
        private PhotonView PV;

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
            PV = GetComponentInParent<PhotonView>();

        }

        private void Start()
        {
            //if (!PV.IsMine) gameObject.SetActive(false);
            UpdateStaminCanvasOverPlayer();
        }

        private void UpdateStaminCanvasOverPlayer()
        {
            image_StaminFill.fillAmount = dashManager.DashStaminFraction;

        }

    }

}
