using Game.Entities;
using Game.Items.Armour;
using Game.Items.Weapons;
using Game.Root;


namespace Game.Town
{
    public class Market
    {
        private Player player;
        private List<Weapon> availableWeapons;
        private List<Armour> availableArmours;

        public Market(Player player)
        {
            this.player = player;

            availableWeapons = new List<Weapon>
            {
                new SteelSword(),
                new Knightblade(),
                new Demonfang()
            };

            availableArmours = new List<Armour>
            {
                new LeatherVest(),
                new Chainmail(),
                new DragonPlate()
            };
        }

        public void Enter()
        {
            while (true)
            {
                Console.WriteLine($"\n--- Market ---");
                Console.WriteLine($"Your Gold: {player.Gold}");
                Console.WriteLine("What would you like to browse?");
                Console.WriteLine("1. Weapons");
                Console.WriteLine("2. Armours");
                Console.WriteLine("0. Exit");

                string input = GameInput.ReadInput();
                if (input == "0") break;

                if (input == "1")
                    BrowseWeapons();
                else if (input == "2")
                    BrowseArmours();
                else
                    Console.WriteLine("Invalid option. Please try again.");
            }
        }

        private void BrowseWeapons()
        {
            while (true)
            {
                Console.WriteLine("\nAvailable Weapons:");
                for (int i = 0; i < availableWeapons.Count; i++)
                {
                    var w = availableWeapons[i];
                    Console.WriteLine($"{i + 1}. {w.Name} - {w.Price} gold");
                }
                Console.WriteLine("0. Back");

                string input = GameInput.ReadInput();
                if (input == "0") break;

                if (int.TryParse(input, out int index) && index >= 1 && index <= availableWeapons.Count)
                {
                    var weapon = availableWeapons[index - 1];
                    if (player.Gold >= weapon.Price)
                    {
                        player.Gold -= weapon.Price;
                        player.Inventory.Add(weapon);
                        Console.WriteLine($"You bought {weapon.Name}.");
                    }
                    else Console.WriteLine("Not enough gold.");
                }
                else Console.WriteLine("Invalid choice.");
            }
        }

        private void BrowseArmours()
        {
            while (true)
            {
                Console.WriteLine("\nAvailable Armours:");
                for (int i = 0; i < availableArmours.Count; i++)
                {
                    var a = availableArmours[i];
                    Console.WriteLine($"{i + 1}. {a.Name} - {a.Price} gold | DEF: {a.Defense}");
                }
                Console.WriteLine("0. Back");

                string input = GameInput.ReadInput();
                if (input == "0") break;

                if (int.TryParse(input, out int index) && index >= 1 && index <= availableArmours.Count)
                {
                    var armour = availableArmours[index - 1];
                    if (player.Gold >= armour.Price)
                    {
                        player.Gold -= armour.Price;
                        player.Inventory.Add(armour); // ← add to inventory
                        Console.WriteLine($"You bought {armour.Name}.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough gold.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
}