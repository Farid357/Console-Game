using System;
using Console_Game.Save_Storages;
using Console_Game.Save_Storages.Paths;

namespace Console_Game.Score
{
    public sealed class ScoreFactory : IFactory<IScore>
    {
        private readonly ISaveStorages _saveStorages;

        public ScoreFactory(ISaveStorages saveStorages)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public IScore Create()
        {
            ISaveStorage<int> scoreCountStorage = new BinaryStorage<int>(new Path(nameof(Score)));
            var startScoreCount = scoreCountStorage.HasSave() ? scoreCountStorage.Load() : 0;
            _saveStorages.Add(scoreCountStorage);
            return new ScoreWithSave(new Score(new ScoreView(), startScoreCount), scoreCountStorage);
        }
    }
}