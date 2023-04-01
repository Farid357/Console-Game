using System.Collections.Generic;
using ConsoleGame.Stats;

namespace ConsoleGame
{
    public interface ILevelsFactory
    {
        List<ILevel> Create();
    }
}