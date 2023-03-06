using System;

namespace Console_Game
{
    public sealed class ScoreView : IScoreView
    {
        public void Visualize(int count)
        {
            Console.WriteLine($"Score: {count}");
        }
    }
}