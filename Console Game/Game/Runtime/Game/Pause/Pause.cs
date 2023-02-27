using System;

namespace Console_Game
{
    public sealed class Pause : IPause
    {
        private readonly IPauseView _view;

        public Pause(IPauseView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsActive { get; private set; }

        public void Enable()
        {
            if (IsActive)
                throw new InvalidOperationException($"Already is active!");
            
            IsActive = true;
            _view.Enable();
        }

        public void Disable()
        {
            if (IsActive)
                throw new InvalidOperationException($"Already is disable!");
            
            IsActive = false;
            _view.Disable();
        }
    }
}