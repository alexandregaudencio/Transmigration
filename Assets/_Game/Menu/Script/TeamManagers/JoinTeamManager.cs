using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoinTeamManager : MonoBehaviourPunCallbacks
{
    private TMP_InputField inputFieldJoinTeam;
    private TMP_Dropdown dropdownJoinTeam;
    string dropdownTeamName
    {
        get
        {
           return  dropdownJoinTeam.options[dropdownJoinTeam.value].text;
        }
    }

    string inputTeamName
    {
        get
        {
            return inputFieldJoinTeam.text;
        }
    }

    private enum  JoinState
    {
        INPUTFIELD_fOCUS,
        DROPDOWN_FOCUS,
        RANDOM_FOCUS
    }

    private JoinState state;


    private void Awake()
    {
        inputFieldJoinTeam = GetComponentInChildren<TMP_InputField>();
        dropdownJoinTeam = GetComponentInChildren<TMP_Dropdown>();

    }

    private void Start()
    {
        state = JoinState.RANDOM_FOCUS;


        inputFieldJoinTeam.onValueChanged.AddListener(delegate
        {
            OnInputFieldValueChanged();
            
        });
        
        dropdownJoinTeam.onValueChanged.AddListener(delegate
        {
            OnDropdownValueChanged();
        });


    }


    private void OnInputFieldValueChanged()
    {
        //Debug.Log("Value: " + inputFieldJoinTeam.text);
        if(inputFieldJoinTeam.text != ""  /*&& inputFieldJoinTeam.text.Length == 3*/ )
        {
            state = JoinState.INPUTFIELD_fOCUS;
        }
    }

    private void OnDropdownValueChanged()
    {
        if(dropdownJoinTeam.options.Count == 0)
        {
            state = JoinState.RANDOM_FOCUS;
        } else
        {
            state = JoinState.DROPDOWN_FOCUS;

        }
    }

    
    //CLICK JOIN TEAM BUTTON
    public void OnClick_JoinRoom()
    {
       
        if(state == JoinState.INPUTFIELD_fOCUS)
        {
            PhotonNetwork.JoinRoom(inputTeamName);
        }
        if (state == JoinState.DROPDOWN_FOCUS)
        {
            PhotonNetwork.JoinRoom(dropdownTeamName);
        }
        if (state == JoinState.RANDOM_FOCUS)
        {
            PhotonNetwork.JoinRandomRoom();

        }
 
    }




}
