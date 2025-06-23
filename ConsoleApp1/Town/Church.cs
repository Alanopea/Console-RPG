using Game.Entities;

namespace Game.Town
{
    public class Church
    {
        private Player player;

        public Church(Player player)
        {
            this.player = player;
        }

        public void Enter()
        {
            Console.WriteLine("\nWelcome to the Church.");

            if (player.XP >= 20)
            {
                int blessings = player.XP / 20;
                int totalIncrease = blessings * 10;

                player.IncreaseMaxHP(totalIncrease);
                player.XP -= blessings * 20;

                Console.WriteLine($"The Father blesses you. You gain +{totalIncrease} Max HP.");
            }
            else
            {
                Console.WriteLine("You do not have enough XP for a blessing.");
            }
        }
    }
}
