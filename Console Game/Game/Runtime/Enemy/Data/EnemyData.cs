using System;
using Newtonsoft.Json;

namespace ConsoleGame
{
    [Serializable]
    public class EnemyData
    {
        public int EnemyTypeId { get; set; }

        public string Name { get; set; }

        public EnemyData(int enemyTypeId, string name)
        {
            EnemyTypeId = enemyTypeId;
            Name = name;
        }
    }
}