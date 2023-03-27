namespace ConsoleGame
{
    public interface IHealthView
    {
        void Visualize(int maxValue, int value);

        void Die();
    }
}