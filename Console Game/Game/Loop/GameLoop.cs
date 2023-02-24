using System;
using System.Threading.Tasks;

namespace Console_Game.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IReadOnlyGameTime _gameTime;
        private readonly GameUpdate _gameUpdate = new GameUpdate();

        public GameLoop(IReadOnlyGameTime gameTime)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public IGameUpdate GameUpdate => _gameUpdate;

        public async void Start()
        {
            while (true)
            {
                if (_gameTime.IsActive)
                {
                    Console.WriteLine();
                    Console.WriteLine(_gameTime.TimeBetweenFrames);
                    _gameUpdate.Update(_gameTime.TimeBetweenFrames);
                    await Task.Yield();
                }

                await Task.Yield();
            }
        }
    }
}