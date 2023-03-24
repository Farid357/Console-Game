namespace Console_Game
{
    public interface IPhysicsMovement : IMovement
    {
        Rigidbody Body { get; }

    }
}