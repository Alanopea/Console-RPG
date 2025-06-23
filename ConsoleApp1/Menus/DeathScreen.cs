using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    public class DeathScreen
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("=======================================");
            Console.WriteLine("               YOU DIED                ");
            Console.WriteLine("=======================================\n");

            Console.WriteLine("The curse was stronger than your will...");
            Console.WriteLine("Your name will fade, your blood spilled in vain.");
            Console.WriteLine("\nPress ENTER to return to the main menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
