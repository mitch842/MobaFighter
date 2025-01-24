public abstract class PlayerState
{
    public abstract string Name { get; }
    public abstract void EnterState(PlayerController playerController);
    public abstract void UpdateState(PlayerController playerController);
}
