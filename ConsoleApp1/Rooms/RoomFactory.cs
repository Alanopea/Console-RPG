using Game.Entities;
using Game.Encounters;
using Game.Entities.Enemies;
using Game.Entities.MiniBosses;
using Game.Items;

namespace Game.Rooms
{
    public class RoomFactory
    {
        private readonly Player player;
        private readonly Random rand = new Random();

        public RoomFactory(Player player)
        {
            this.player = player;
        }

        public Room CreateRandomRoom()
        {
            if (rand.NextDouble() < 0.3)
            {
                Item treasure = new HealthPotion();
                return new Room(new TreasureEncounter(player, treasure));
            }
            else
            {
                int enemyCount = rand.Next(1, 4);
                List<Enemy> enemies = new List<Enemy>();

                for (int i = 0; i < enemyCount; i++)
                {
                    int choice = rand.Next(4);
                    enemies.Add(choice switch
                    {
                        0 => new Wolf(),
                        1 => new Bear(),
                        2 => new Skeleton(),
                        _ => new Goblin(),
                    });
                }

                if (enemies.Count == 1)
                    return new Room(new CombatEncounter(player, enemies[0]));
                else
                    return new Room(new MultiEnemyEncounter(player, enemies));
            }
        }

        public Room CreateMiniBossRoom()
        {
            return new Room(new CombatEncounter(player, new VampireMiniBoss()));
        }
    }
}
