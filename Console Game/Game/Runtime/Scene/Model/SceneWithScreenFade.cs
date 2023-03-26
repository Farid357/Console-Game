using System;
using System.Threading.Tasks;

namespace ConsoleGame.LoadSystem
{
    public sealed class SceneWithScreenFade : IAsyncScene
    {
        private readonly IAsyncScene _scene;
        private readonly IScreen _screen;

        public SceneWithScreenFade(IAsyncScene scene, IScreen screen)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _screen = screen ?? throw new ArgumentNullException(nameof(screen));
        }

        public float LoadingProgress => _scene.LoadingProgress;
        
        public bool IsLoaded => _scene.IsLoaded;

        public async Task Load()
        {
            await _screen.FadeIn();
            await _scene.Load();
            await _screen.FadeOut();
        }

        public async Task Unload()
        {
            await _scene.Unload();
        }
    }
}