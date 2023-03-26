using System;
using System.Collections.Generic;
using ConsoleGame.Save_Storages;

namespace ConsoleGame.Shop
{
    public sealed class CollectionSaveStorage<T> : ICollectionSaveStorage<T>
    {
        private readonly List<T> _items;
        private readonly ISaveStorage<List<T>> _saveStorage;

        public CollectionSaveStorage(ISaveStorage<List<T>> saveStorage)
        {
            _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
            _items = _saveStorage.HasSave() ? _saveStorage.Load() : new List<T>();
        }

        public IReadOnlyList<T> Items => _items;

        public void Remove(T item)
        {
            _items.Remove(item);
            Save();
        }

        public void Add(T item)
        {
            _items.Add(item);
            Save();
        }
        
        private void Save() => _saveStorage.Save(_items);
        
        public bool HasSave() => _saveStorage.HasSave();

        public void DeleteSave()
        {
            _saveStorage.DeleteSave();
        }
    }
}