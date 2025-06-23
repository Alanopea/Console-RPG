using Game.Items;

namespace Game.Inventory
{
    public class Bag
    {
        public List<Item> UsableItems { get; private set; }
        public const int MaxItems = 5;

        public Bag()
        {
            UsableItems = new List<Item>();
        }

        public bool AddItem(Item item)
        {
            if (IsFull())
            {
                Console.WriteLine("Your bag is full! Drop an item before adding a new one.");
                return false;
            }

            UsableItems.Add(item);
            Console.WriteLine($"{item.Name} added to your bag.");
            return true;
        }

        public void DropItem(int index)
        {
            int adjustedIndex = index - 1;

            if (adjustedIndex >= 0 && adjustedIndex < UsableItems.Count)
            {
                Console.WriteLine($"{UsableItems[adjustedIndex].Name} was dropped.");
                UsableItems.RemoveAt(adjustedIndex);
            }
            else
            {
                Console.WriteLine("Invalid item index.");
            }
        }

        public void ShowContents()
        {
            if (UsableItems.Count == 0)
            {
                Console.WriteLine("\nYour bag is empty.");
                return;
            }

            Console.WriteLine("\n-- Bag Contents --");
            for (int i = 0; i < UsableItems.Count; i++)
                Console.WriteLine($"{i + 1}. {UsableItems[i].Name}");
        }

        public bool IsFull()
        {
            return UsableItems.Count >= MaxItems;
        }

        public bool IsEmpty()
        {
            return UsableItems.Count == 0;
        }
    }
}
