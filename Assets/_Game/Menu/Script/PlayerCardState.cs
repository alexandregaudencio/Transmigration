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
        SwitchObjectActivity(EnterState.OFF);
    }

    private void Update()
    {
        if(inputJoystick.StartInputDown)
        {
            SwitchObjectActivity(EnterState.ON);
        }
    }

    private void SwitchObjectActivity(EnterState state)
    {
        foreach (PlayerEnterState es in EnterStateList)
        {
            es.ObjectTarget.SetActive(es.State == state);
        }
    }
}

public enum EnterState
{
    OFF,
    ON
}

[Serializable]
public class PlayerEnterState
{
    [SerializeField]
    private EnterState state;
    [SerializeField]
    private GameObject objectTarget;

    public PlayerEnterState(EnterState state, GameObject objectTarget)
    {
        this.State = state;
        this.ObjectTarget = objectTarget;
    }

    public EnterState State { get => state; set => state = value; }
    public GameObject ObjectTarget { get => objectTarget; set => objectTarget = value; }
}
