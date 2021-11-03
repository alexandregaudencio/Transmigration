

public  class ListedStates
{
    public  readonly StandardState standardState;
    public readonly DeathState deathState;
    public  ListedStates()
    {
        standardState = new StandardState();
        deathState = new DeathState();
    }

}
