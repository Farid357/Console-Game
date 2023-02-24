namespace Console_Game
{
    public interface IHealthView
    {
        void Visualize(int maxValue, int value);

        void Die();
    }
}