using System.Numerics;

namespace ConsoleGame
{
    public interface IAim
    {
        Vector3 Position { get; }
        
        Vector3 Target { get; }
    }
}