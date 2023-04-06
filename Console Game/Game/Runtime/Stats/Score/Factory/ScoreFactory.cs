using System;
using ConsoleGame.SaveSystem;
using ConsoleGame.Tools;

namespace ConsoleGame
{
    public sealed class ScoreFactory : IScoreFactory
    {
        private readonly ISaveStorages _saveStorages;
        private readonly IScoreViewFactory _viewFactory;

        public ScoreFactory(ISaveStorages saveStorages, IScoreViewFactory viewFactory)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IScore Create()
        {
            ISaveStorage<int> scoreCountStorage = new BinaryStorage<int>(new Path(nameof(IScore)));
            int scoreCount = scoreCountStorage.LoadOrDefault();
            _saveStorages.Add(scoreCountStorage);
            IScoreView scoreView = _viewFactory.Create(scoreCount);
            return new ScoreWithSave(new Score(scoreView, scoreCount), scoreCountStorage);
        }
    }
}