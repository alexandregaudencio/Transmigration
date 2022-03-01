using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoinTeamManager : MonoBehaviourPunCallbacks
{
    //private Button buttonJoinTeam;
    [SerializeField] private TMP_InputField inputFieldJoinTeam;
    [SerializeField] private TMP_Dropdown dropdownJoinTeam;

    private enum  JoinState
    {
        INPUTFIELD_fOCUS,
        DROPDOWN_FOCUS,
        RANDOM_FOCUS
    }

    private JoinState state;


    private void Awake()
    {
        //buttonJoinTeam = GetComponent<Button>();

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
        if(inputFieldJoinTeam != null  && inputFieldJoinTeam.text.Length == 3)
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
    public void JoinRoom()
    {
       
        if(state == JoinState.INPUTFIELD_fOCUS)
        {
           
        } else
        {
            if (state == JoinState.DROPDOWN_FOCUS)
            {
                string teamTarget = dropdownJoinTeam.options[dropdownJoinTeam.value].text;
                PhotonNetwork.JoinRoom(teamTarget);
            }
            if (state == JoinState.RANDOM_FOCUS)
            {
                PhotonNetwork.JoinRandomRoom();

            }
        }


    }




}
