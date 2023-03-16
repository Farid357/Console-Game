using System;
using System.Threading.Tasks;

namespace Console_Game.LoadSystem
{
    public sealed class SceneWithScreenFade : IScene
    {
        private readonly IScene _scene;
        private readonly IScreen _screen;

        public SceneWithScreenFade(IScene scene, IScreen screen)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _screen = screen ?? throw new ArgumentNullException(nameof(screen));
        }

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