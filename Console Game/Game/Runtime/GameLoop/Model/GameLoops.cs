using System;
using System.Collections.Generic;

namespace ConsoleGame.GameLoop
{
    public sealed class GameLoops : IGameLoop
    {
        private readonly List<IGameLoop> _all;

        public GameLoops(List<IGameLoop> all)
        {
            _all = all ?? throw new ArgumentNullException(nameof(all));
        }

        public void Start()
        {
            foreach (IGameLoop gameLoop in _all)
            {
                gameLoop.Start();
            }
        }
    }
}