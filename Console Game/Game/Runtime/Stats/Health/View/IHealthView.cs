namespace ConsoleGame
{
    public interface IHealthView
    {
        void Visualize(int health, int maxHealth);

        void Die();
    }
}