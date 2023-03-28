namespace ConsoleGame
{
    public sealed class EnemyHealthViewFactory : IHealthViewFactory
    {
        public IHealthView Create()
        {
            return new EnemyHealthView();
        }
    }
}