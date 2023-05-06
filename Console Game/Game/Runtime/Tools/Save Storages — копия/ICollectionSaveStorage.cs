using System.Collections.Generic;
using ConsoleGame.SaveSystem;

namespace ConsoleGame.Shop
{
    public interface ICollectionSaveStorage<T> : ISaveStorage
    {
        void Add(T item);
        
        void Remove(T item);
        
        IReadOnlyList<T> Items { get; }
    }
}