using Photon.Pun;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    PhotonView photonview;
    private ExitGames.Client.Photon.Hashtable HashProperty = new ExitGames.Client.Photon.Hashtable();
    private int maxHP =>  (int)photonview.Controller.CustomProperties["maxHP"];
    private int hp => (int)photonview.Controller.CustomProperties["HP"];

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            HashProperty["HP"] = value;
            PV.Controller.SetCustomProperties(HashProperty);
        }
    }
    public void IncreaseHP(int value)
    {
        if(HP <= maxHP)
        {
            HP += value;
        }
    }
    public void DecreaseHP(int value)
    {
        if (HP <= maxHP)
        {
            HP -= value;
        }
    }

    public float HPfraction
    {
        get
        {
            return (float)hp / maxHP;
        }
    }


    private void Awake()
    {
        photonview = GetComponent<PhotonView>();
    }


    public PhotonView PV { get => photonview; set => photonview = value; }

    public void ResetPlayerPrps(Vector3 spawnPosition)
    {
        //TODO: not working great.
        HashProperty["HP"] = (int)PhotonNetwork.LocalPlayer.CustomProperties["maxHP"];
        HashProperty["isDead"] = false;
        PhotonNetwork.LocalPlayer.SetCustomProperties(HashProperty);
        GetComponent<SpriteRenderer>().enabled = true;
        transform.position = spawnPosition;


    }
}
