using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleGame.SaveSystem
{
    public sealed class BinaryStorage<TStoreValue> : ISaveStorage<TStoreValue>
    {
        private readonly BinaryFormatter _formatter = new BinaryFormatter();
        private readonly string _pathName;

        public BinaryStorage(SaveSystem.IPath path)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            _pathName = path.Name;
        }

        public bool HasSave() => File.Exists(_pathName);

        public void DeleteSave()
        {
            if (HasSave() == false)
                throw new CannotDeleteSaveException(nameof(TStoreValue), _pathName);

            File.Delete(_pathName);
        }

        public TStoreValue Load()
        {
            if (HasSave() == false)
                throw new HasNotSaveException(nameof(TStoreValue), _pathName);

            using (FileStream file = File.Open(_pathName, FileMode.Open))
                return (TStoreValue)_formatter.Deserialize(file);
        }

        public void Save(TStoreValue value)
        {
            using (FileStream file = File.Create(_pathName))
                _formatter.Serialize(file, value);
        }
    }
}