using System;
using System.Diagnostics;
using ConsoleGame.Rendering;

namespace ConsoleGame.GameLoop
{
    public sealed class RenderingLoop : IGameLoop
    {
        private readonly IRenderer _renderer;
        private readonly Stopwatch _stopwatch;
        
        public RenderingLoop(IRenderer renderer)
        {
            _renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
            _stopwatch = new Stopwatch();
        }

        public void Start()
        {
            _stopwatch.Start();
            TimeSpan lastUpdateTime = _stopwatch.Elapsed;

            while (true)
            {
                TimeSpan deltaTime = _stopwatch.Elapsed - lastUpdateTime;
                lastUpdateTime += deltaTime;
                float deltaTimeInSeconds = (float)deltaTime.TotalSeconds;

                if (_renderer.IsAlive)
                    _renderer.Render(deltaTimeInSeconds);
            }
        }
    }
}