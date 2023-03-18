using System.Collections.Generic;

namespace Console_Game
{
    public interface IGroup<T>
    {
        IReadOnlyList<T> All { get; }
        
        void Add(T instance);
     
        void Remove(T instance);
        
    }
}