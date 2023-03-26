namespace ConsoleGame.Loop
{
    public interface IGameLoop
    {
        IGameLoopObjectsGroup Objects { get; }

        void Start();
    }
}