using System;
using System.Threading.Tasks;

namespace Console_Game.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly GameUpdate _gameUpdate = new();
        private readonly IReadOnlyGameTime _gameTime;

        public GameLoop(IReadOnlyGameTime gameTime)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public IGameUpdate GameUpdate => _gameUpdate;

        public async void StartUpdating()
        {
            while (true)
            {
                if (_gameTime.IsActive)
                {
                    await Task.Delay(TimeSpan.FromSeconds(_gameTime.Delta));
                    _gameUpdate.Update(_gameTime.Delta);
                }

                await Task.Yield();
            }
        }
    }
}