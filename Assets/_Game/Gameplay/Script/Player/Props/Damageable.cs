using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviourPunCallbacks, IDamageable
{
    public event Action DamageEvent;
    //public event Action DeathEvent;

    PhotonView PV;
    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();

    PlayerProperty playerProperty;
    PlayerController playerController;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        playerProperty = GetComponent<PlayerProperty>();
        playerController = GetComponent<PlayerController>();
    }


    public void TakeDamage(int damage)
    {
        playerProperty.HP = -damage;
        playerController.Animator.SetTrigger("hurt");
        playerController.AudioManager.PlayAudio(playerController.AudioManager.hurtClip, false);
        //int hp = (int)PV.Controller.CustomProperties["HP"];
        //HashProperty["HP"] = hp - damage;
        //PV.Controller.SetCustomProperties(HashProperty);
        DamageEvent?.Invoke();

    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {

        if (PV.Controller == targetPlayer && changedProps.ContainsKey("HP"))
        {
            if((int)targetPlayer.CustomProperties["HP"] <= 0 && !(bool)targetPlayer.CustomProperties["isDead"])
            {
                HashProperty["isDead"] = true;
                PV.Controller.SetCustomProperties(HashProperty);
                GetComponent<PlayerController>().GoToDeathState();

            }
        }
    }






}
