using System;

namespace Console_Game.Score
{
    public sealed class ScoreView : IScoreView
    {
        public void Visualize(int count)
        {
            Console.WriteLine($"Score: {count}");
        }
    }
}