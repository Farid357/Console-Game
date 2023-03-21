using System;
using System.Numerics;
using Console_Game.Save_Storages;
using Console_Game.Save_Storages.Paths;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class ScoreFactory : IFactory<IScore>
    {
        private readonly ISaveStorages _saveStorages;
        private readonly ITextFactory _textFactory;
        
        public ScoreFactory(ISaveStorages saveStorages, ITextFactory textFactory)
        {
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IScore Create()
        {
            ISaveStorage<int> scoreCountStorage = new BinaryStorage<int>(new Path(nameof(IScore)));
            var startScoreCount = scoreCountStorage.HasSave() ? scoreCountStorage.Load() : 0;
            _saveStorages.Add(scoreCountStorage);
            IText scoreText = _textFactory.Create(new Transform(new Vector2(100, 100)));
            IScoreView scoreView = new ScoreView(scoreText);
            IScore score = new ScoreWithSave(new Score(scoreView, startScoreCount), scoreCountStorage);
            scoreView.Visualize(score.Count);
            return score;
        }
    }
}