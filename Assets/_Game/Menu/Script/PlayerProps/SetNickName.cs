
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class SetNickName : MonoBehaviour
{
    private TMP_InputField InputField_username;
    
    private void Awake()
    {
        InputField_username = GetComponent<TMP_InputField>();

    }

    private void Start()
    {
        InputField_username.onValueChanged.AddListener(delegate
        {
            OnInputfieldValueChanged();
        });
        
        InitializeInpuifield();

    }

    private void InitializeInpuifield()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            InputField_username.text = PlayerPrefs.GetString("username");
        }
        else
        {
            InputField_username.text = "Player #" + Random.Range(1, 99).ToString("00");
        }
    }

    public void OnInputfieldValueChanged()
    {
        string usernameText = InputField_username.text;
        PlayerPrefs.SetString("username", usernameText);
        PhotonNetwork.NickName = usernameText;
        Debug.Log("Nick " + PhotonNetwork.NickName);
    }



}
