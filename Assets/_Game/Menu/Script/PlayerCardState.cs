using PlayerDataNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCardState : MonoBehaviour
{

    [SerializeField]
    private List<PlayerEnterState> EnterStateList;

    private InputJoystick inputJoystick;
    private void Awake()
    {
        inputJoystick = GetComponent<InputJoystick>();
    }
    private void Start()
    {
        SwitchCardActivity(CardState.OFF);
    }

    private void Update()
    {
        if(inputJoystick.StartInputDown)
        {
            SwitchCardActivity(CardState.ON);
        }
    }

    private void SwitchCardActivity(CardState state)
    {
        foreach (PlayerEnterState es in EnterStateList)
        {
            es.ObjectTarget.SetActive(es.State == state);
        }
    }
}

public enum CardState
{
    OFF,
    ON
}

[Serializable]
public class PlayerEnterState
{
    [SerializeField]
    private CardState state;
    [SerializeField]
private GameObject objectTarget;

    public PlayerEnterState(CardState state, GameObject objectTarget)
    {
        this.State = state;
        this.ObjectTarget = objectTarget;
    }

    public CardState State { get => state; set => state = value; }
    public GameObject ObjectTarget { get => objectTarget; set => objectTarget = value; }
}
