using Game.Entities;

namespace Game.Items
{
    public class HealthPotion : Item
    {
        private static readonly Random rng = new Random();

        public HealthPotion() : base("Health Potion") { }

        public override void Use(Player player)
        {
            player.HP += 10;
            Console.WriteLine($"{player.Name} uses a Health Potion and heals for 10 HP.");
        }
    }
}
