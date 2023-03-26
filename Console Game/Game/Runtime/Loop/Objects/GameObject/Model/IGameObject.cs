namespace ConsoleGame
{
    public interface IGameObject : IGameLoopObject
    {
        bool IsActive { get; }
    }
}