using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownTeamList : MonoBehaviourPunCallbacks
{
    private TMP_Dropdown dropdown;
    public string teamTarget;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void Start()
    {
        AddEventListenerDropdownChange();

    }

    private void AddEventListenerDropdownChange()
    {
        //TODO: descomentar código abaixo
        //dropdown.ClearOptions();
        dropdown.onValueChanged.AddListener(delegate
        {
            teamTarget = dropdown.options[dropdown.value].text;

        });

    }

}
