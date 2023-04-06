namespace ConsoleGame
{
    public sealed class EnemyHealthViewFactory : IHealthViewFactory
    {
        public IHealthView Create()
        {
            IHealthView view = new EnemyHealthView();
            return view;
        }
    }
}