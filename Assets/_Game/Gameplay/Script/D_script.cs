using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class D_script : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "";

        foreach (Player p in PhotonNetwork.PlayerList)
        {
            GetComponent<Text>().text = GetComponent<Text>().text  + "Name: " + p.NickName + "\n" +
                "HP: " + (int)p.CustomProperties["HP"] + "\n" +
            "isDead: " + (bool)p.CustomProperties["isDead"] + "\n"+".......";
        }
            


    }
}
