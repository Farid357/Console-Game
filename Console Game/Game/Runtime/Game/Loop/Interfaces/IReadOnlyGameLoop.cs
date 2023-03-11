namespace Console_Game.Loop
{
    public interface IReadOnlyGameLoop
    {
        IGroup<IGameLoopObject> Objects { get; }
    }
}