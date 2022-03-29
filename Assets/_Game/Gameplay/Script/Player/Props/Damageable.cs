using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;

public class Damageable : MonoBehaviourPunCallbacks, IDamageable
{
    //public event Action<float> DamageEvent;
    //public event Action DeathEvent;

    private PhotonView PV;
    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();
    //PhotonPlayerProperty playerProperty;
    private PlayerController playerController;
    private HPManager hpManager;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        //playerProperty = GetComponent<PhotonPlayerProperty>();
        playerController = GetComponent<PlayerController>();
        hpManager = GetComponent<HPManager>();

    }


    public void TakeDamage(float damage)
    {
        if(PV.IsMine)
        {
            playerController.Animator.SetTrigger("hurt");
            playerController.AudioManager.PlayAudio(playerController.AudioManager.hurtClip, false);
            
            hpManager.DecreaseHP(damage);
            //DamageEvent?.Invoke(damage);
        }

    }




    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {

        if (PV.Controller == targetPlayer && changedProps.ContainsKey("HP"))
        {
            if((float)targetPlayer.CustomProperties["HP"] <= 0 && !(bool)targetPlayer.CustomProperties["isDead"])
            {
                HashProperty["isDead"] = true;
                PV.Controller.SetCustomProperties(HashProperty);
                playerController.GoToDeathState();

            }
        }
    }






}
