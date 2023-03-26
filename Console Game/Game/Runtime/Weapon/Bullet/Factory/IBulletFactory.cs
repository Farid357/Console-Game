namespace ConsoleGame.Weapons
{
    public interface IBulletFactory
    {
        IBullet Create(int damage);
    }
}