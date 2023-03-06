using System;
using Console_Game.Loop;
using Console_Game.Save_Storages;
using Console_Game.Save_Storages.Paths;

namespace Console_Game
{
    public sealed class ScoreBestRecordFactory : IScoreBestRecordFactory
    {
        private readonly ISaveStorages _saveStorages;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;

        public ScoreBestRecordFactory(ISaveStorages saveStorages, IGroup<IGameLoopObject> gameLoopObjects)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
        }

        public IScoreBestRecord Create(IScore score)
        {
            if (score == null) 
                throw new ArgumentNullException(nameof(score));

            ISaveStorage<int> recordStorage = new BinaryStorage<int>(new Path(nameof(IScoreBestRecord)));
            var scoreBestRecord = new ScoreBestRecord(score, recordStorage, new ScoreBestRecordView());
            _gameLoopObjects.Add(scoreBestRecord);
            return scoreBestRecord;
        }
    }
}