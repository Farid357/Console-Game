using System;
using System.Numerics;
using Console_Game.Save_Storages;
using Console_Game.Save_Storages.Paths;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class ScoreBestRecordFactory : IScoreBestRecordFactory
    {
        private readonly ISaveStorages _saveStorages;
        private readonly IGroup<IGameLoopObject> _gameLoopObjects;
        private readonly ITextFactory _textFactory;
        
        public ScoreBestRecordFactory(ISaveStorages saveStorages, IGroup<IGameLoopObject> gameLoopObjects, ITextFactory textFactory)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _gameLoopObjects = gameLoopObjects ?? throw new ArgumentNullException(nameof(gameLoopObjects));
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IScoreBestRecord Create(IScore score)
        {
            if (score == null) 
                throw new ArgumentNullException(nameof(score));

            ISaveStorage<int> recordStorage = new BinaryStorage<int>(new Path(nameof(IScoreBestRecord)));
            IText text = _textFactory.Create(new Transform(new Vector2(200, 100)));
            IScoreBestRecordView bestRecordView = new ScoreBestRecordView(text);
            var scoreBestRecord = new ScoreBestRecord(score, recordStorage, bestRecordView);
            _gameLoopObjects.Add(scoreBestRecord);
            _saveStorages.Add(recordStorage);
            return scoreBestRecord;
        }
    }
}