namespace Console_Game.Tools
{
    public interface IPool<TItem>
    {
        TItem Get();
        
        void Return(TItem item);
    }
}