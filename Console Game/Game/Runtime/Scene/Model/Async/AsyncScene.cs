using System;
using System.Threading.Tasks;

namespace Console_Game.LoadSystem
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
            
            await _scene.Load();
        }

        public async Task Unload()
        {
            await _scene.Unload();
        }
    }
}