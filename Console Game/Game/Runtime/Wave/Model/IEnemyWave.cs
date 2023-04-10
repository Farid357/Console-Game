using System.Collections.Generic;
using System.Numerics;

namespace ConsoleGame
{
    public interface IEnemyWave
    {
        bool IsEnded { get; }
        
        void Start();
    }
}