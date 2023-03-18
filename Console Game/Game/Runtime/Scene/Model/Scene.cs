namespace Console_Game.LoadSystem
{
    public sealed class Scene : IScene
    {
        public bool IsLoaded { get; private set; }
        
        public void Load()
        {
            //Load
            IsLoaded = true;
        }

        public void Unload()
        {
            //Unload
            IsLoaded = false;
        }
    }
}