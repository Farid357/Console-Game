using System;
using ConsoleGame.Save_Storages;

namespace ConsoleGame
{
    public sealed class Achievement : IAchievement
    {
        private readonly IAchievementView _view;
        private readonly ISaveStorage<bool> _wasReceivedStorage;

        public Achievement(IAchievementView view, ISaveStorage<bool> wasReceivedStorage)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _wasReceivedStorage = wasReceivedStorage ?? throw new ArgumentNullException(nameof(wasReceivedStorage));
            CanReceive = _wasReceivedStorage.HasSave() ? false : true;
        }

        public bool CanReceive { get; private set; }
        
        public void Receive()
        {
            if (CanReceive == false)
                throw new Exception($"Achievement is already received!");
            
            CanReceive = false;
            _view.ReceiveWithCongratulations();
            _wasReceivedStorage.Save(CanReceive);
        }
    }
}