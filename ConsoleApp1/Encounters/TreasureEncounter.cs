using Game.Entities;
using Game.Items;
using Game.Root;

namespace Game.Encounters
{
    public class TreasureEncounter : IEncounter
    {
        private readonly Player player;
        private readonly Item treasure;

        public TreasureEncounter(Player player, Item treasure)
        {
            this.player = player;
            this.treasure = treasure;
        }

        public void Execute(Player _)
        {
            DisplayTreasure();
        }

        public bool ExecuteAndReturnIfFled(Player _)
        {
            DisplayTreasure();
            return false; 
        }

        private void DisplayTreasure()
        {
            Console.WriteLine($"\nYou found a treasure: {treasure.Name}");

            if (player.Bag.IsFull())
            {
                Console.WriteLine("Your bag is full! You must drop an item to pick this up.");
                player.Bag.ShowContents();

                Console.WriteLine("Choose an item to drop (enter index or -1 to skip taking this item):");
                if (int.TryParse(GameInput.ReadInput(), out int choice) && choice >= 0 && choice < player.Bag.UsableItems.Count)
                {
                    player.Bag.DropItem(choice);
                    player.Bag.AddItem(treasure);
                    Console.WriteLine($"You picked up: {treasure.Name}");
                }
                else
                {
                    Console.WriteLine("You left the treasure behind.");
                }
            }
            else
            {
                player.Bag.AddItem(treasure);
                Console.WriteLine($"You picked up: {treasure.Name}");
            }
        }
    }
}