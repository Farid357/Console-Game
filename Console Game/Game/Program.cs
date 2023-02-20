using System;
using Console_Game.Loop;
using Console_Game.Weapons;

namespace Console_Game
{
    public sealed class Program
    {
        public static void Main()
        {
        }
    }

    public sealed class Game
    {
        public Game()
        {
            IGameTime gameTime = new GameTime();
            IGameLoop gameLoop = new GameLoop(gameTime);
            IGameUpdate gameUpdate = gameLoop.GameUpdate;
            IWeaponInput weaponInput = new WeaponInput(new Key(ConsoleKey.F));
            IFactory<IWeaponWithMagazine> weaponFactory = new StartPlayerWeaponFactory(gameUpdate);
            IWeaponWithMagazine weapon = weaponFactory.Create();
            IPlayerSimulation playerSimulation = new PlayerSimulation(gameUpdate);
            playerSimulation.CreatePlayer(weaponInput, weapon);
            gameLoop.StartUpdating();
        }
    }
}