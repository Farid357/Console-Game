using System.Collections.Generic;
using Console_Game.Save_Storages;

namespace Console_Game.Shop
{
    public interface ICollectionSaveStorage<T> : ISaveStorage
    {
        void Add(T item);
        
        void Remove(T item);
        
        IReadOnlyList<T> Items { get; }
    }
}