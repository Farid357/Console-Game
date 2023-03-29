using System;
using System.Threading.Tasks;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class AchievementReceiveWindow : IAchievementReceiveWindow
    {
        private readonly IWindow _window;
        private readonly IText _congratulationText;

        public AchievementReceiveWindow(IWindow window, IText congratulationText)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            _congratulationText = congratulationText ?? throw new ArgumentNullException(nameof(congratulationText));
        }

        public async void Show(string congratulationText)
        {
            _window.Open();
            _congratulationText.Visualize(congratulationText);
            await Task.Delay(TimeSpan.FromSeconds(2.5f));
            _window.Close();
            _congratulationText.Clear();
        }
    }
}