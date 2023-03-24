using System;
using System.Threading.Tasks;
using Console_Game.Tools;
using Console_Game.UI;

namespace Console_Game.Shop
{
    public sealed class NotEnoughMoneyView : INotEnoughMoneyView
    {
        private readonly IText _text;

        public NotEnoughMoneyView(IText text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public async void Enable()
        {
            _text.Visualize($"Not enough money!");
            await Task.Delay(TimeSpan.FromSeconds(0.35f));
            _text.Clear();
        }
    }
}