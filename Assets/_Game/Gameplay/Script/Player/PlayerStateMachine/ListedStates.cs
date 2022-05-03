namespace  PlayerStateMachine{
    public class ListedStates
    {
        public readonly StandardState standardState;
        public readonly DeathState deathState;
        public readonly DashState dashState;
        public readonly MeditateState meditateState;
        public ListedStates()
        {
            meditateState = new MeditateState();
            standardState = new StandardState();
            deathState = new DeathState();
            dashState = new DashState();
        }

    }

}
