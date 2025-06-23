using Game.Entities;

namespace Game.Items
{
    public abstract class Item
    {
        public string Name { get; }

        public Item(string name)
        {
            Name = name;
        }

        public abstract void Use(Player player);
    }
}