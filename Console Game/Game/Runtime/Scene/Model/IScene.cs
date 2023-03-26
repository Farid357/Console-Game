namespace ConsoleGame.LoadSystem
{
    public interface IScene
    {
        bool IsLoaded { get; }
        
        void Load();

        void Unload();
    }
}