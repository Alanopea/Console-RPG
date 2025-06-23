using Game.Entities;

namespace Game.Items.Weapons
{
    public abstract class Weapon : Item
    {
        public int BaseDamage { get; protected set; }
        public List<Attack> Attacks { get; protected set; }
        public int Price { get; protected set; }

        public Weapon(string name, int price) : base(name)
        {
            Price = price;
            Attacks = new List<Attack>();
        }

        public override void Use(Player player)
        {
            player.EquippedWeapon = this;
            Console.WriteLine($"Equipped weapon: {Name}");
        }
    }

    public class Attack
    {
        public string Name { get; }
        public int Damage { get; }
        public int Speed { get; }
        public double MissChance { get; }

        public Attack(string name, int damage, int speed, double missChance = 0)
        {
            Name = name;
            Damage = damage;
            Speed = speed;
            MissChance = missChance;
        }

        public bool AttemptHit()
        {
            return new Random().NextDouble() >= MissChance;
        }
    }
}
