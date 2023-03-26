namespace ConsoleGame
{
    public interface IGroup<in T>
    {
        void Add(T instance);
     
        void Remove(T instance);
        
    }
}