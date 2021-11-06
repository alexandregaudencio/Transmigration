
public  class ListedStates
{
    public  readonly StandardState standardState;
    public readonly DeathState deathState;
    public readonly DashState dashState;
    public  ListedStates()
    {
        standardState = new StandardState();
        deathState = new DeathState();
        dashState = new DashState();
    }

}
