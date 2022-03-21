using Photon.Pun;
using PlayerStateMachine;
using UnityEngine;


public class StateController : MonoBehaviourPunCallbacks
{
    private State currentState;
    private PlayerController playerController;
    private ListedStates listedStates;

    public ListedStates ListedStates { get => listedStates; set => listedStates = value; }

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        ListedStates = new ListedStates();
    }

    private void Start()
    {

        TransitionToState(ListedStates.standardState);
    }


    public virtual void TransitionToState(State state)
    {
        if(playerController.PV.IsMine)
        {
            currentState = state;
            currentState.EnterState(playerController, this);
        }

    }

    void Update()
    {
        if (playerController.PV.IsMine)
        {
            currentState.UpdateState(playerController, this);

        }
    }

    protected void FixedUpdate()
    {
        if (playerController.PV.IsMine)
        { 
            currentState.FixedUpdateState(playerController, this);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerController.PV.IsMine)
        {
            currentState.OnCollisionEnter(playerController, collision, this);
        }
    }





}
