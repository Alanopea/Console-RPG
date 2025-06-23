using Game.Inventory;
using Game.Root;
using Game.Rooms;

namespace Game.States
{
    public class DungeonState : IState
    {
        private readonly GameManager manager;

        public DungeonState(GameManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            Console.WriteLine("\nYou are about to enter the dungeon...");

            // Open inventory before entering
            PlayerInventory inventory = new PlayerInventory(manager.Player);
            inventory.OpenInventory();

            // Start dungeon
            Console.WriteLine("\nYou enter the dungeon...");
            Dungeon dungeon = new Dungeon(manager.Player);

            // Check if dungeon was cleared or fled
            bool cleared = dungeon.Explore();

            if (cleared)
            {
                Console.WriteLine("\nYou have cleared the dungeon! Congratulations!");
            }
            else
            {
                Console.WriteLine("\nYou have fled the dungeon safely.");
            }
        }
    }
}

