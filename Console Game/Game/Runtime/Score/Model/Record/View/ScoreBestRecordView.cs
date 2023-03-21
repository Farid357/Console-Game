using System;
using System.Drawing;
using System.Threading.Tasks;
using Console_Game.UI;

namespace Console_Game
{
    public sealed class ScoreBestRecordView : IScoreBestRecordView
    {
        private readonly IText _text;

        public ScoreBestRecordView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public async void Visualize(int record)
        {
            _text.Visualize($"Score Best Record: {record}");
            var startTextColor = _text.Color;
            _text.SwitchColor(Color.Crimson);
            await Task.Delay(TimeSpan.FromSeconds(1.5f));
            _text.SwitchColor(startTextColor);
        }
    }
}