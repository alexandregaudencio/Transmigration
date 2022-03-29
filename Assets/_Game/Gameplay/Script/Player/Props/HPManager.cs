using Photon.Pun;
using System;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public event Action<float> changeHPEvent;
    private PhotonView photonview;
    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();
    public float MaxHP =>  (float)photonview.Controller.CustomProperties["maxHP"];
    public float HP => (float)photonview.Controller.CustomProperties["HP"];
    public PhotonView PV => photonview;

    public float HPfraction
    {
        get
        {
            return (float)HP / MaxHP;
        }
    }

    private void Awake()
    {
        photonview = GetComponent<PhotonView>();
    }

    public void IncreaseHP(float value)
    {
        if(PV.IsMine)
        {
            if (HP <= MaxHP)
            {
                HashProperty["HP"] = HP + value;
                PV.Controller.SetCustomProperties(HashProperty);
                changeHPEvent?.Invoke(value);

            }
        }
 
    }
    public void DecreaseHP(float value)
    {
        if(PV.IsMine)
        {
            if (HP <= MaxHP)
            {
                HashProperty["HP"] = HP - value;
                PV.Controller.SetCustomProperties(HashProperty);
                changeHPEvent?.Invoke(value);
            }
        }


    }


    public void ResetPlayerPrps(Vector3 spawnPosition)
    {
        //TODO: not working great.
        HashProperty["HP"] = (float)PhotonNetwork.LocalPlayer.CustomProperties["maxHP"];
        HashProperty["isDead"] = false;
        PhotonNetwork.LocalPlayer.SetCustomProperties(HashProperty);
        GetComponent<SpriteRenderer>().enabled = true;
        transform.position = spawnPosition;


    }
}
