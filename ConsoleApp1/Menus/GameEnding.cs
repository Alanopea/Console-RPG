using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    public class GameEnding
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("=======================================");
            Console.WriteLine("           CURSE HAS BEEN LIFTED       ");
            Console.WriteLine("=======================================\n");

            Console.WriteLine("You have defeated Lord Malgar and shattered the curse that haunted these lands.");
            Console.WriteLine("The dungeon collapses behind you, and sunlight finally pierces through the darkness.");
            Console.WriteLine("Your name will be sung by those who live, and feared by those who lurk in the shadows.\n");

            Console.WriteLine("Thank you for playing Bloodbound: Curse of the Dungeon.\n");

            Console.WriteLine("Press ENTER to return to the main menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
