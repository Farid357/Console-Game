namespace Console_Game.Save_Storages
{
    public interface ISaveStorage<TStoreValue> : ICanDeleteSaveStorage
    {
        TStoreValue Load();

        void Save(TStoreValue value);
    }
}