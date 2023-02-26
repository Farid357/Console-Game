namespace Console_Game
{
    public interface IPhysicsMovement : IMovement
    {
        PhysicsBody Body { get; }

    }
}