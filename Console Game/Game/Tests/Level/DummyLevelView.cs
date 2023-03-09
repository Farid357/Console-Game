using System;
using System.Diagnostics;
using Console_Game.Stats;

namespace Console_Game.Tests
{
    [Serializable]
    public sealed class DummyLevelView : ILevelView
    {
        private string _levelOwnerName;

        public DummyLevelView(string levelOwnerName)
        {
            _levelOwnerName = levelOwnerName;
        }

        public void Visualize(int xp, int maxXp)
        {
            Debug.Write(_levelOwnerName);
        }
    }
}