namespace Console_Game.Save_Storages
{
    public interface ISaveStorages
    {
        bool HasSaves();
        
        void Add(ISaveStorage storage);
        
        void DeleteAllSaves();

    }
}