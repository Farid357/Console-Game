namespace Console_Game.LoadSystem
{
    public interface IScene
    {
        bool IsLoaded { get; }
        
        void Load();

        void Unload();
    }
}