using Game.Entities;

namespace Game.Quests
{
    public class WolvesQuest : Quest
    {
        public int WolvesKilled { get; private set; }

        public WolvesQuest(string name, string description) : base(name, description)
        {
            WolvesKilled = 0;
        }

        public override void TrackProgress(string enemyName)
        {
            if (IsCompleted) return;

            if (enemyName == "Wolf")
            {
                WolvesKilled++;
                Console.WriteLine($"Quest Progress: Wolves killed {WolvesKilled}/3");

                if (WolvesKilled >= 3)
                {
                    IsCompleted = true;
                    Console.WriteLine("Quest Update: You have killed 3 wolves! Return to the bar.");
                }
            }
        }

        public override void ShowProgress()
        {
            Console.WriteLine($"Wolves killed: {WolvesKilled}/3");
        }

        public override void RewardPlayer(Player player)
        {
            Console.WriteLine("The shady drunkard grins. \"Good work. Here's your reward.\"");
            player.Gold += 75;
            Console.WriteLine("You received 75 gold!");
        }
    }
}
