using System;

namespace Console_Game
{
    public sealed class ArmorView : IHealthView
    {
        private bool _isFixed;
        
        public void Visualize(int maxValue, int value)
        {
            if (_isFixed == false)
                Fix();
            
            Console.WriteLine($"Armor: {maxValue}/{value}");
        }

        public void VisualizeDeath() => Break();

        public void Fix()
        {
            Console.WriteLine($"Armor is active!");
            _isFixed = true;
        }

        public void Break()
        {
            Console.WriteLine($"Armor is broken!");
            _isFixed = false;
        }
    }
}