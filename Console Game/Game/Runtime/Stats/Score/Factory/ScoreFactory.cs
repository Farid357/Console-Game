using System;
using ConsoleGame.SaveSystem;

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
            int startScoreCount = scoreCountStorage.HasSave() ? scoreCountStorage.Load() : 0;
            _saveStorages.Add(scoreCountStorage);
            IScoreView scoreView = _viewFactory.Create();
            IScore score = new ScoreWithSave(new Score(scoreView, startScoreCount), scoreCountStorage);
            scoreView.Visualize(score.Count);
            return score;
        }
    }
}