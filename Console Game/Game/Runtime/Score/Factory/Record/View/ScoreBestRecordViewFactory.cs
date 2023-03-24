using System;
using System.Drawing;
using System.Numerics;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class ScoreBestRecordViewFactory : IScoreBestRecordViewFactory
    {
        private readonly ITextFactory _textFactory;

        public ScoreBestRecordViewFactory(ITextFactory textFactory)
        {
            _textFactory = textFactory ?? throw new ArgumentNullException(nameof(textFactory));
        }

        public IScoreBestRecordView Create()
        {
            ITransform transform = new Transform(new Vector2(200, 100));
            Font font = new Font("Arial", 18);
            IText text = _textFactory.Create(transform, font, Color.Gold);
            IScoreBestRecordView view = new ScoreBestRecordView(text);
            return view;
        }
    }
}