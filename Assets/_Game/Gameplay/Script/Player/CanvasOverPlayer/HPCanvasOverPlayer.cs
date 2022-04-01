using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasOverPlayerNamespace
{
    public class HPCanvasOverPlayer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Image image_hpFill;
        [SerializeField] private HPManager hpManager;
        [SerializeField] private Damageable damageable;

        private new void OnEnable()
        {
            hpManager.changeHPEvent += UpdateHPCanvasOverPlayer;
        }
        private new void OnDisable()
        {
            hpManager.changeHPEvent -= UpdateHPCanvasOverPlayer;
        }
        //private void Start()
        //{
        //    UpdateHPCanvasOverPlayer();  
        //}

        //public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        //{
        //    if (PV.Controller == targetPlayer && changedProps.ContainsKey("HP"))
        //    {
        //        UpdateHPCanvasOverPlayer();
        //    }
        //}

        public void UpdateHPCanvasOverPlayer(float hp)
        {
            image_hpFill.fillAmount = hpManager.HPfraction ;
            //Debug.Log("HP in Manager: " + hpManager.HP);

        }


    }
}

