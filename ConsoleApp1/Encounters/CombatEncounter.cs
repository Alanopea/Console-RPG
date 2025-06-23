using Game.Entities;
using Game.Entities.Enemies;
using Game.Entities.MiniBosses;
using Game.Root;

namespace Game.Encounters
{
    public class CombatEncounter : IEncounter
    {
        private Player player;
        private Enemy enemy;

        public bool PlayerFled { get; private set; } = false;

        public CombatEncounter(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void Execute(Player player)
        {
            Console.WriteLine($"\nYou encounter a {enemy.Name}!");

            while (player.HP > 0 && enemy.HP > 0 && !PlayerFled)
            {
                Console.WriteLine($"\nYour HP: {player.HP} | {enemy.Name} HP: {enemy.HP}");

                string choice = "";
                bool validChoice = false;

                // Input Validation Loop
                while (!validChoice)
                {
                    Console.WriteLine("\nChoose your action:");
                    Console.WriteLine("1. Fast Attack");
                    Console.WriteLine("2. Heavy Attack");
                    Console.WriteLine("3. Use item");
                    Console.WriteLine("4. Flee");

                    choice = GameInput.ReadInput();

                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                    {
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 1, 2, 3, or 4.");
                    }
                }

                if (choice == "1")
                {
                    var atk = player.EquippedWeapon.Attacks[0];
                    enemy.HP -= atk.Damage;
                    Console.WriteLine($"You use {atk.Name} and deal {atk.Damage} damage.");
                    player.HealAfterAttack();
                }
                else if (choice == "2")
                {
                    var atk = player.EquippedWeapon.Attacks[1];

                    Console.WriteLine("Enemy attacks first!");
                    enemy.Attack(player);
                    if (player.HP <= 0) break;

                    if (new Random().Next(100) < 30)
                    {
                        Console.WriteLine($"Your {atk.Name} missed!");
                    }
                    else
                    {
                        enemy.HP -= atk.Damage;
                        Console.WriteLine($"You use {atk.Name} and deal {atk.Damage} damage.");
                        player.HealAfterAttack();
                    }
                }
                else if (choice == "3")
                {
                    if (player.Bag.IsEmpty())
                    {
                        Console.WriteLine("Your bag is empty. Nothing to use.");
                        continue; // Don't end turn
                    }

                    player.Bag.ShowContents();
                    Console.WriteLine("Choose item index to use, or press 9 to cancel:");

                    if (int.TryParse(GameInput.ReadInput(), out int index))
                    {
                        if (index == 9)
                        {
                            Console.WriteLine("You chose not to use anything.");
                            continue; // Don't end turn
                        }

                        index -= 1;
                        if (index >= 0 && index < player.Bag.UsableItems.Count)
                        {
                            var item = player.Bag.UsableItems[index];
                            player.UseItem(item);
                            player.Bag.DropItem(index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid item index.");
                            continue; // Don't end turn
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        continue; // Don't end turn
                    }
                }
                else if (choice == "4")
                {
                    PlayerFled = true;
                    Console.WriteLine("You fled the battle!");
                    break;
                }

                if (enemy.HP > 0 && !PlayerFled)
                {
                    enemy.Attack(player);
                }
            }

            if (player.HP > 0 && !PlayerFled)
            {
                Console.WriteLine($"\nYou defeated {enemy.Name}!");
                player.XP += enemy.XPReward;

                if (enemy is VampireMiniBoss vampire)
                {
                    vampire.OnDefeated(player);
                }

                if (player.ActiveQuest != null && !player.ActiveQuest.IsCompleted)
                {
                    player.ActiveQuest.TrackProgress(enemy.Name);
                }
            }
            else if (PlayerFled)
            {
                Console.WriteLine("\nYou fled the combat.");
            }
            else
            {
                Console.WriteLine("\nYou died...");
            }
        }

        public bool ExecuteAndReturnIfFled(Player player)
        {
            Execute(player);
            return PlayerFled;
        }
    }
}
