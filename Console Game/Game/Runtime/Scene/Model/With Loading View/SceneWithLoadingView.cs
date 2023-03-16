using System;
using System.Threading.Tasks;

namespace Console_Game.LoadSystem
{
    public sealed class SceneWithLoadingView : IScene
    {
        private readonly IAsyncScene _scene;
        private readonly ISceneLoadingView _loadingView;

        public SceneWithLoadingView(IAsyncScene scene, ISceneLoadingView loadingView)
        {
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
            _loadingView = loadingView ?? throw new ArgumentNullException(nameof(loadingView));
        }

        public bool IsLoaded => _scene.IsLoaded;

        public async Task Load()
        {
            _loadingView.Enable();
            _scene.Load();

            while (!_scene.IsLoaded)
            {
                _loadingView.Visualize(_scene.LoadingProgress);
                await Task.Yield();
            }
            
            _loadingView.Disable();
        }

        public async Task Unload()
        {
            await _scene.Unload();
        }
    }
}