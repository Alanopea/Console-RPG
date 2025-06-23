using Game.Entities;

namespace Game.Rooms
{
    public class Dungeon
    {
        private readonly Player player;
        private readonly RoomFactory factory;
        private readonly Random rand = new Random();

        public Dungeon(Player player)
        {
            this.player = player;
            this.factory = new RoomFactory(player);
        }

        public bool Explore()
        {
            int totalRooms = rand.Next(3, 6);

            for (int i = 0; i < totalRooms; i++)
            {
                Console.WriteLine($"\n--- Room {i + 1} ---");
                var room = factory.CreateRandomRoom();

                // Execute the encounter and check if the player fled
                bool playerFled = room.Encounter.ExecuteAndReturnIfFled(player);

                if (player.HP <= 0)
                {
                    Console.WriteLine("You died in the dungeon.");
                    return false;
                }

                if (playerFled)
                {
                    Console.WriteLine("You fled from the dungeon!");
                    return false;
                }
            }

            //Vampire chance to appear
            if (rand.NextDouble() < 0.5)
            {
                Console.WriteLine("\n!!! A mysterious room appears...");
                var minibossRoom = factory.CreateMiniBossRoom();
                bool playerFled = minibossRoom.Encounter.ExecuteAndReturnIfFled(player);

                if (player.HP <= 0)
                {
                    Console.WriteLine("You died in the dungeon.");
                    return false;
                }

                if (playerFled)
                {
                    Console.WriteLine("You fled from the dungeon!");
                    return false;
                }
            }

            return true; // Dungeon cleared
        }
    }
}