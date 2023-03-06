using System;
using Newtonsoft.Json;

namespace Console_Game
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