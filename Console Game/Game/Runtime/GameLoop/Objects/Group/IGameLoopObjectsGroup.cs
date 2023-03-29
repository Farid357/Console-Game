namespace ConsoleGame.GameLoop
{
    public interface IGameLoopObjectsGroup
    {
        void Add(IGameLoopObject loopObject);

        void Remove(IGameLoopObject loopObject);
    }
}