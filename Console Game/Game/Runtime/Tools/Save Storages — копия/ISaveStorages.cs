namespace ConsoleGame.SaveSystem
{
    public interface ISaveStorages
    {
        bool HasSaves();
        
        void Add(ISaveStorage storage);
        
        void DeleteAllSaves();

    }
}