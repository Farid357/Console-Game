using System;

namespace ConsoleGame
{
    public sealed class GrenadeView : IGrenadeView
    {
        private readonly IGameObjectView _gameObjectView;

        public GrenadeView(IGameObjectView gameObjectView)
        {
            _gameObjectView = gameObjectView ?? throw new ArgumentNullException(nameof(gameObjectView));
        }

        public void Destroy()
        {
            _gameObjectView.Destroy();
        }
    }
}