using System;
using System.Threading.Tasks;

namespace ConsoleGame.LoadSystem
{
    public sealed class AsyncScene : IAsyncScene
    {
        private readonly IScene _scene;

        public AsyncScene(IScene scene)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
        }

        public bool IsLoaded => _scene.IsLoaded;
        
        public float LoadingProgress { get; private set; }

        public async Task Load()
        {
            var time = 0f;
            
            while (time < 1f)
            {
                await Task.Yield();
                time += 0.1f;
                LoadingProgress = time;
            }
            
            _scene.Load();
        }

        public async Task Unload()
        {
            _scene.Unload();
            await Task.Yield();
        }
    }
}