using System;
using Console_Game.Save_Storages;
using Console_Game.Save_Storages.Paths;

namespace Console_Game
{
    public sealed class ScoreBestRecordFactory : IScoreBestRecordFactory
    {
        private readonly ISaveStorages _saveStorages;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly IScoreBestRecordViewFactory _viewFactory;

        public ScoreBestRecordFactory(ISaveStorages saveStorages, IGroup<IGameLoopObject> gameLoopObjects, IScoreBestRecordViewFactory viewFactory)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IScoreBestRecord Create(IScore score)
        {
            if (score == null) 
                throw new ArgumentNullException(nameof(score));

            ISaveStorage<int> recordStorage = new BinaryStorage<int>(new Path(nameof(IScoreBestRecord)));
            IScoreBestRecordView view = _viewFactory.Create();
            var scoreBestRecord = new ScoreBestRecord(score, recordStorage, view);
            _gameLoopObjects.Add(scoreBestRecord);
            _saveStorages.Add(recordStorage);
            return scoreBestRecord;
        }
    }
}