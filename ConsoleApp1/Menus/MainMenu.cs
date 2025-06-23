using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    public class MainMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("=======================================");
            Console.WriteLine("      BLOODBOUND: CURSE OF THE DUNGEON ");
            Console.WriteLine("=======================================\n");

            Console.WriteLine("A dark force lurks beneath the earth...");
            Console.WriteLine("Your fate is written in blood.");
            Console.WriteLine("Survive. Conquer. Escape the curse.\n");

            Console.WriteLine("Press ENTER to begin your journey...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
