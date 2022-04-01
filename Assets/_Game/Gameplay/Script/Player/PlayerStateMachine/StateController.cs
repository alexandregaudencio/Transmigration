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

            currentState = state;
            currentState.EnterState(playerController, this);

    }

    void Update()
    {

            currentState.UpdateState(playerController, this);


    }

    protected void FixedUpdate()
    {
        currentState.FixedUpdateState(playerController, this);  
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(playerController, collision, this);

    }





}
