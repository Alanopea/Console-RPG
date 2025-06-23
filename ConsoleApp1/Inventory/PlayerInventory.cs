using Game.Entities;
using Game.Items.Armour;
using Game.Items.Weapons;
using Game.Root;

namespace Game.Inventory
{
    public class PlayerInventory
    {
        private readonly Player player;

        public PlayerInventory(Player player)
        {
            this.player = player;
        }

        public void OpenInventory()
        {
            Console.WriteLine($"\n--- Preparing for the Expedition ---");
            SelectWeapon();
            SelectArmour();
        }

        private void SelectWeapon()
        {
            var weapons = player.Inventory.OfType<Weapon>().ToList();
            if (weapons.Count == 0)
            {
                Console.WriteLine("You have no weapons to equip.");
                return;
            }

            Console.WriteLine("\nSelect a Weapon:");
            for (int i = 0; i < weapons.Count; i++)
                Console.WriteLine($"{i + 1}. {weapons[i].Name}");

            int choice = GetChoice(weapons.Count);
            player.EquippedWeapon = weapons[choice - 1];
            Console.WriteLine($"{player.EquippedWeapon.Name} equipped.");
        }

        private void SelectArmour()
        {
            var armours = player.Inventory.OfType<Armour>().ToList();
            if (armours.Count == 0)
            {
                Console.WriteLine("You have no armour to equip.");
                return;
            }

            Console.WriteLine("\nSelect an Armour:");
            for (int i = 0; i < armours.Count; i++)
                Console.WriteLine($"{i + 1}. {armours[i].Name}");

            int choice = GetChoice(armours.Count);
            player.EquippedArmour = armours[choice - 1];
            Console.WriteLine($"{player.EquippedArmour.Name} equipped.");
        }

        

        private int GetChoice(int max, bool allowZero = false)
        {
            int choice;
            while (!int.TryParse(GameInput.ReadInput(), out choice) ||
                   choice < (allowZero ? 0 : 1) || choice > max)
            {
                Console.WriteLine("Invalid choice. Try again:");
            }
            return choice;
        }
    }
}
