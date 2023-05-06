using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.SaveSystem
{
    public sealed class SaveStorages : ISaveStorages
    {
        private readonly List<ISaveStorage> _all = new List<ISaveStorage>();

        public bool HasSaves() => _all.Any(storage => storage.HasSave());

        public void Add(ISaveStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));

            _all.Add(storage);
        }

        public void DeleteAllSaves()
        {
            if (HasSaves() == false)
                throw new InvalidOperationException($"SaveStorages can't delete saves, because doesn't contain them!");

            foreach (var storage in _all.Where(storage => storage.HasSave()))
            {
                storage.DeleteSave();
            }
        }
    }
}