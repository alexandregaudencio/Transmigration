using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviourPunCallbacks, IDamageable
{

    PhotonView PV;
    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();

    PlayerProperty playerProperty;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        playerProperty = GetComponent<PlayerProperty>();
    }


    public void TakeDamage(int damage)
    {
        playerProperty.HP = -damage;
        GetComponent<PlayerController>().Animator.SetTrigger("hurt");
        //int hp = (int)PV.Controller.CustomProperties["HP"];
        //HashProperty["HP"] = hp - damage;
        //PV.Controller.SetCustomProperties(HashProperty);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {

        if (PV.Controller == targetPlayer && changedProps.ContainsKey("HP"))
        {
            if((int)targetPlayer.CustomProperties["HP"] <= 0 && !(bool)targetPlayer.CustomProperties["isDead"])
            {
                HashProperty["isDead"] = true;
                PV.Controller.SetCustomProperties(HashProperty);
            }
        }
    }

}
