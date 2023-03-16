using System.Threading.Tasks;

namespace Console_Game.LoadSystem
{
    public sealed class Scene : IScene
    {
        public bool IsLoaded { get; private set; }
        
        public Task Load()
        {
            //Load
            IsLoaded = true;
            return Task.CompletedTask;
        }

        public Task Unload()
        {
            //Unload
            IsLoaded = false;
            return Task.CompletedTask;
        }
    }
}