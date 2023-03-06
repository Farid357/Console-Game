using System;

namespace Console_Game.Score
{
    public sealed class ScoreBestRecordView : IScoreBestRecordView
    {
        public void Visualize(int record)
        {
            Console.WriteLine($"Score Best Record: {record}");
        }
    }
}