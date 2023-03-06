using System;

namespace Console_Game
{
    public sealed class ScoreBestRecordView : IScoreBestRecordView
    {
        public void Visualize(int record)
        {
            Console.WriteLine($"Score Best Record: {record}");
        }
    }
}