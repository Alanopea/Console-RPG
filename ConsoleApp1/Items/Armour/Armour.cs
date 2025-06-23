using Game.Entities;

namespace Game.Items.Armour
{
    public class Armour : Item
    {
        public int Defense { get; }
        public int Price { get; }

        public Armour(string name, int defense, int price) : base(name)
        {
            Defense = defense;
            Price = price;
        }

        public override void Use(Player player)
        {
            player.EquippedArmour = this;
            Console.WriteLine($"Equipped armour: {Name}");
        }
    }
}
