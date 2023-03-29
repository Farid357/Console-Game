using System;
using ConsoleGame.UI;

namespace ConsoleGame
{
    public sealed class AchievementView : IAchievementView
    {
        private readonly IImage _checkmark;
        private readonly IAchievementReceiveWindow _receiveWindow;

        public AchievementView(IImage checkmark, IAchievementReceiveWindow receiveWindow)
        {
            _checkmark = checkmark ?? throw new ArgumentNullException(nameof(checkmark));
            _receiveWindow = receiveWindow ?? throw new ArgumentNullException(nameof(receiveWindow));
        }

        public void Receive()
        {
            _checkmark.Enable();
        }

        public void ReceiveWithCongratulation(string congratulation)
        {
            _receiveWindow.Show(congratulation);
        }
    }
}