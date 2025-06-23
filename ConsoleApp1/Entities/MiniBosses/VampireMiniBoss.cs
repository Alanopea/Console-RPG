using Game.Entities.Enemies;

namespace Game.Entities.MiniBosses
{
    public class VampireMiniBoss : Enemy
    {
        private Random rand = new Random();

        public VampireMiniBoss()
            : base("Vampire", 80, 15, 15, new List<(string, int, int)>
            {
                ("Blood Bite", 12, 15),
                ("Shadow Claw", 20, 10)
            })
        {
        }

        public override void Attack(Player player)
        {
            base.Attack(player);

            int drain = rand.Next(5, 11);
            HP += drain;
            Console.WriteLine($"{Name} drains {drain} HP from {player.Name} and heals itself!");
        }

        public void OnDefeated(Player player)
        {
            Console.WriteLine("As the Vampire dies, you feel cursed blood latching onto your veins...");
            Console.WriteLine("You have permanently gained the Bloodbending ability!");
            player.HasBloodbending = true;

            Console.WriteLine("The Vampire's body crumbles, leaving behind a pouch of gold.");
            player.Gold += 40;
            Console.WriteLine("You gain 40 gold.");
        }
    }
}
