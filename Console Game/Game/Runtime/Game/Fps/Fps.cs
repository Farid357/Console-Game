using System;

namespace Console_Game.Loop
{
    public sealed class Fps : IFps
    {
        public int Current { get; private set; }

        public int Calculate(float deltaTime, long elapsedMilliseconds)
        {
            if (elapsedMilliseconds <= 0)
                throw new ArgumentOutOfRangeException(nameof(elapsedMilliseconds));
            
            Current = (int)(deltaTime % elapsedMilliseconds);
            return Current;
        }
    }
}