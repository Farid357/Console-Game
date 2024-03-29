using System;
using ConsoleGame.SaveSystem;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class ScoreBestRecord : IGameLoopObject, IScoreBestRecord
    {
        private readonly IScore _score;
        private readonly ISaveStorage<int> _countStorage;
        private readonly IScoreBestRecordView _view;
        
        public ScoreBestRecord(IScore score, ISaveStorage<int> countStorage, IScoreBestRecordView view)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _countStorage = countStorage ?? throw new ArgumentNullException(nameof(countStorage));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            Count = _countStorage.LoadOrDefault();
        }
        
        public int Count { get; private set; }

        public void Update(float deltaTime)
        {
            if (_score.Count > Count)
            {
                Count = _score.Count;
                _countStorage.Save(Count);
                _view.Visualize(Count);
            }
        }
    }
}