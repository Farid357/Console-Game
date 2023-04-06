using System;
using System.Diagnostics;
using ConsoleGame.Stats;

namespace ConsoleGame.Tests
{
    [Serializable]
    public sealed class DummyLevelView : ILevelView
    {
        public void Visualize(int xp, int maxXp)
        {
            Debug.Write($"{xp} {maxXp}");
        }
    }
}