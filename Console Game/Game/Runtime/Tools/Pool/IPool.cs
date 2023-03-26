namespace ConsoleGame.Tools
{
    public interface IPool<TItem>
    {
        TItem Get();
        
        void Return(TItem item);
    }
}