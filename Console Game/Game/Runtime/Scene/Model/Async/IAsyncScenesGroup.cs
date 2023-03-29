namespace ConsoleGame.LoadSystem
{
    public interface IAsyncScenesGroup
    {
        void Add(IAsyncScene instance);
        
        void Remove(IAsyncScene instance);
    }
}