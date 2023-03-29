using System.Collections.Generic;

namespace ConsoleGame
{
    public interface IChainOfAchievement
    {
        IReadOnlyList<IAchievement> Achievements { get; }
        
    }
}