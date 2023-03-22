namespace Console_Game.Weapons
{
    public interface IBulletsFactory
    {
        IBullet Create(int damage);
    }
}