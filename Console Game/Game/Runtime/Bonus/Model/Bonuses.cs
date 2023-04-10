using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame
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
        
        public bool IsAlive { get; private set; }

        public void Pick()
        {
            if (!IsAlive)
                throw new Exception($"Bonus isn't alive!");
            
            IsAlive = false;
            foreach (IBonus bonus in _all)
            {
                bonus.Pick();
            }
        }

    }
}