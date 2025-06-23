using Game.Entities;

namespace Game.Quests
{
    public class VampireQuest : Quest
    {
        public bool VampireKilled { get; private set; }

        public VampireQuest(string name, string description) : base(name, description)
        {
            VampireKilled = false;
        }

        public override void TrackProgress(string enemyName)
        {
            if (IsCompleted) return;

            if (enemyName == "Vampire")
            {
                VampireKilled = true;
                IsCompleted = true;
                Console.WriteLine("Quest Update: You have killed the vampire! Return to the bar.");
            }
        }

        public override void ShowProgress()
        {
            Console.WriteLine($"Vampire killed: {(VampireKilled ? "Yes" : "No")}");
        }

        public override void RewardPlayer(Player player)
        {
            Console.WriteLine("The shady drunkard whispers. \"You’ve done the town a great service. Here's your reward.\"");
            player.Gold += 200;
            Console.WriteLine("You received 200 gold!");
        }
    }
}
