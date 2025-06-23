using Game.Entities;

namespace Game.Items
{
    public class DarkDagger : Item
    {
        public DarkDagger() : base("Dark Dagger") { }

        public override void Use(Player player)
        {
            Console.WriteLine("The Dark Dagger whispers… ‘Only he who sheds divine blood shall see truth.’ It cannot be used now.");
        }
    }
}
