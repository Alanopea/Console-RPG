using Game.Entities;
using Game.Entities.Enemies;

namespace Game.Encounters
{
    public class MultiEnemyEncounter : IEncounter
    {
        private readonly Player player;
        private readonly List<Enemy> enemies;

        public MultiEnemyEncounter(Player player, List<Enemy> enemies)
        {
            this.player = player;
            this.enemies = enemies;
        }

        public void Execute(Player player)
        {
            foreach (var enemy in enemies)
            {
                Console.WriteLine($"\nNext enemy: {enemy.Name} (HP: {enemy.HP})");

                var encounter = new CombatEncounter(player, enemy);
                encounter.Execute(player);

                if (player.HP <= 0)
                {
                    return;
                }

                if (encounter.PlayerFled)
                {
                    return;
                }
            }

            Console.WriteLine("You cleared the room!");
        }

        public bool ExecuteAndReturnIfFled(Player player)
        {
            foreach (var enemy in enemies)
            {
                Console.WriteLine($"\nNext enemy: {enemy.Name} (HP: {enemy.HP})");

                var encounter = new CombatEncounter(player, enemy);
                encounter.Execute(player);

                if (player.HP <= 0)
                {
                    return false;
                }

                if (encounter.PlayerFled)
                {
                    return true;
                }
            }
            return false;
        }
    }
}