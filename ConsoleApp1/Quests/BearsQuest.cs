using Game.Entities;

namespace Game.Quests
{
    public class BearsQuest : Quest
    {
        public int BearsKilled { get; private set; }

        public BearsQuest(string name, string description) : base(name, description)
        {
            BearsKilled = 0;
        }

        public override void TrackProgress(string enemyName)
        {
            if (IsCompleted) return;

            if (enemyName == "Bear")
            {
                BearsKilled++;
                Console.WriteLine($"Quest Progress: Bears killed {BearsKilled}/2");

                if (BearsKilled >= 2)
                {
                    IsCompleted = true;
                    Console.WriteLine("Quest Update: You have killed 2 bears! Return to the bar.");
                }
            }
        }

        public override void ShowProgress()
        {
            Console.WriteLine($"Bears killed: {BearsKilled}/2");
        }

        public override void RewardPlayer(Player player)
        {
            Console.WriteLine("The shady drunkard grins. \"Good work. Here's your reward.\"");
            player.Gold += 100;
            Console.WriteLine("You received 100 gold!");
        }
    }
}
