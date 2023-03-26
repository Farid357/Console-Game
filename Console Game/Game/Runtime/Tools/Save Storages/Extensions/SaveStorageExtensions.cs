using ConsoleGame.Save_Storages;

namespace ConsoleGame
{
    public static class SaveStorageExtensions
    {
        public static void DeleteSaveIfHas<TStoreValue>(this ISaveStorage<TStoreValue> saveStorage)
        {
            if(saveStorage.HasSave())
                saveStorage.DeleteSave();
        }
    }
}