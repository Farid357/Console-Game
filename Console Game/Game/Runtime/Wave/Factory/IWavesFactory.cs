using System.Collections.Generic;

namespace ConsoleGame.Wave
{
    public interface IWavesFactory
    {
        List<IWave> Create();
    }
}