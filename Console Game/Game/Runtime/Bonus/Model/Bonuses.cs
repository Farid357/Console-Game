using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Bonus
{
    public sealed class Bonuses : IBonus
    {
        private readonly List<IBonus> _all;

        public Bonuses(IEnumerable<IBonus> all)
        {
            if (all == null) 
                throw new ArgumentNullException(nameof(all));

            _all = all.ToList();
        }

        public void Pick()
        {
            foreach (IBonus bonus in _all)
            {
                bonus.Pick();
            }
        }
    }
}