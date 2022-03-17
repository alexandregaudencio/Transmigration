using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

[RequireComponent(typeof(TMP_Text))]
public class ShowPlayerName : MonoBehaviourPunCallbacks
{
    private TMP_Text text_NickName;
    // Start is called before the first frame update
    void Start()
    {
        text_NickName = GetComponent<TMP_Text>();
    }

    private new void OnEnable()
    {
        //text_NickName.text = "Bem-vindo, \n" + PhotonNetwork.NickName;
        StartCoroutine(ChangeNickText());

    }

    private new void OnDisable()
    {
        text_NickName.text = "...";
    }

    private IEnumerator ChangeNickText()
    {
        yield return new WaitForSeconds(0.2f);
        text_NickName.text = "Bem-vindo, \n" + PhotonNetwork.NickName;

    }
}
