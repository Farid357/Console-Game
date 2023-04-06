using System;
using ConsoleGame.GameLoop;
using ConsoleGame.SaveSystem;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class ScoreBestRecordFactory : IScoreBestRecordFactory
    {
        private readonly ISaveStorages _saveStorages;
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IScoreBestRecordViewFactory _viewFactory;

        public ScoreBestRecordFactory(ISaveStorages saveStorages, IGameLoopObjectsGroup gameLoop, IScoreBestRecordViewFactory viewFactory)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IScoreBestRecord Create(IScore score)
        {
            if (score == null) 
                throw new ArgumentNullException(nameof(score));

            ISaveStorage<int> recordStorage = new BinaryStorage<int>(new Path(nameof(IScoreBestRecord)));
            IScoreBestRecordView view = _viewFactory.Create(recordStorage.LoadOrDefault());
            var scoreBestRecord = new ScoreBestRecord(score, recordStorage, view);
            _gameLoop.Add(scoreBestRecord);
            _saveStorages.Add(recordStorage);
            return scoreBestRecord;
        }
    }
}