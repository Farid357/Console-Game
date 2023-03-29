namespace ConsoleGame.SaveSystem
{
    public interface ISaveStorage<TStoreValue> : ISaveStorage
    {
        TStoreValue Load();

        void Save(TStoreValue value);
    }

    public interface ISaveStorage
    {
        bool HasSave();
        
        void DeleteSave();
    }
}