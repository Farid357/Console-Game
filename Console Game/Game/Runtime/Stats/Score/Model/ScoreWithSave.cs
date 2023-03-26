using System;
using ConsoleGame.Save_Storages;

namespace ConsoleGame
{
    public sealed class ScoreWithSave : IScore
    {
        private readonly IScore _score;
        private readonly ISaveStorage<int> _saveStorage;

        public ScoreWithSave(IScore score, ISaveStorage<int> saveStorage)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _saveStorage = saveStorage ?? throw new ArgumentNullException(nameof(saveStorage));
        }

        public int Count => _score.Count;

        public void Raise(int count)
        {
            _score.Raise(count);
            _saveStorage.Save(_score.Count);
        }
    }
}