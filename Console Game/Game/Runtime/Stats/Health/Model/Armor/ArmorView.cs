using System;

namespace ConsoleGame
{
    public sealed class ArmorView : IArmorView
    {
        private bool _isFixed;
        
        public void Visualize(int value)
        {
            if (_isFixed == false)
                Fix();
            
            Console.WriteLine($"Armor: {value}");
            
            if(value == 0)
                Break();
        }

        private void Break()
        {
            Console.WriteLine($"Armor is broken!");
            _isFixed = false;
        }

        private void Fix()
        {
            Console.WriteLine($"Armor is active!");
            _isFixed = true;
        }
    }
}