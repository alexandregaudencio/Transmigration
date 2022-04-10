using UnityEngine;

namespace PlayerStateMachine
{
    public class StateController : MonoBehaviour
    {
        private State currentState;
        private PlayerController playerController;
        private ListedStates listedStates;

        //private void OnGUI()
        //{

        //    float time = Time.fixedTime;
        //    GUI.Label(new Rect(10, 25, 500, 100), "sin: " + Mathf.Sin(time));
        //}
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

        private void Update()
        {

            currentState.UpdateState(playerController, this);


        }

        private void FixedUpdate()
        {
            currentState.FixedUpdateState(playerController, this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            currentState.OnCollisionEnter(playerController, collision, this);
        }

        public void GoDeathState()
        {
            TransitionToState(listedStates.deathState);
        }

        public void GoStandardState()
        {
            TransitionToState(listedStates.standardState);
        }



    }

}

