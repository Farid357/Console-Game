using System;
using System.Threading.Tasks;
using ConsoleGame.Tools;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class AchievementView : IAchievementView
    {
        private readonly IWindow _congratulationWindow;
        private readonly IText _congratulationsText;
        private readonly IImage _checkmark;
        private readonly string _congratulationText;

        public AchievementView(IWindow congratulationWindow, IText congratulationsText, IImage checkmark, string congratulationText)
        {
            _congratulationWindow = congratulationWindow ?? throw new ArgumentNullException(nameof(congratulationWindow));
            _congratulationsText = congratulationsText ?? throw new ArgumentNullException(nameof(congratulationsText));
            _checkmark = checkmark ?? throw new ArgumentNullException(nameof(checkmark));
            _congratulationText = congratulationText ?? throw new ArgumentNullException(nameof(congratulationText));
        }

        public void Receive()
        {
            _checkmark.Enable();
        }

        public async void ReceiveWithCongratulations()
        {
            Receive();
            _congratulationWindow.Open();
            _congratulationsText.Visualize(_congratulationText);
            await Task.Delay(TimeSpan.FromSeconds(2.5f));
            _congratulationWindow.Close();
            _congratulationsText.Clear();
        }
    }
}