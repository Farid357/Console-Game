using System.Collections.Generic;
using ConsoleGame.Save_Storages;

namespace ConsoleGame.Shop
{
    public interface ICollectionSaveStorage<T> : ISaveStorage
    {
        void Add(T item);
        
        void Remove(T item);
        
        IReadOnlyList<T> Items { get; }
    }
}