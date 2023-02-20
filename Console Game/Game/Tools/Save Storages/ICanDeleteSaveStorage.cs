namespace Console_Game.Save_Storages
{
    public interface ICanDeleteSaveStorage
    {
        bool HasSave();

        void DeleteSave();
    }
}