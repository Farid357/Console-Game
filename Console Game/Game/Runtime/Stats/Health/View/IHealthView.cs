namespace ConsoleGame
{
    public interface IHealthView
    {
        void Visualize(int value, int maxValue);

        void Die();
    }
}