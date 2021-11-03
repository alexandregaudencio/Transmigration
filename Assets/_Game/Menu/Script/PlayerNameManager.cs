using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameManager : MonoBehaviour
{
    TMP_InputField usernameInput;

    private void Awake()
    {
        usernameInput = GetComponent<TMP_InputField>();

    }

    private void Start()
    {

        if (PlayerPrefs.HasKey("username"))
        {
            usernameInput.text = PlayerPrefs.GetString("username");
            PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        }
        else
        {
            usernameInput.text = "Player #" + Random.Range(1, 99).ToString("00");
            OnUsernameInputValueChange();
        }
    }

    public void OnUsernameInputValueChange()
    {
        PhotonNetwork.NickName = usernameInput.text;
        //Debug.Log(PhotonNetwork.NickName);
        PlayerPrefs.SetString("username", usernameInput.text);
    }
}
