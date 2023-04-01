using System;

namespace ConsoleGame.Bonus
{
    public sealed class BonusWithView : IBonus
    {
        private readonly IBonus _bonus;
        private readonly IBonusView _view;

        public BonusWithView(IBonus bonus, IBonusView view)
        {
            _bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Pick()
        {
            _bonus.Pick();
            _view.Destroy();
        }
    }
}