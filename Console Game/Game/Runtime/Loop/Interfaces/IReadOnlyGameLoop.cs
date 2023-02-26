namespace Console_Game.Loop
{
    public interface IReadOnlyGameLoop
    {
        IGameUpdate GameUpdate { get; }
    }
}