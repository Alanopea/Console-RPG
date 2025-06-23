using Game.Entities;
using Game.Quests;

namespace Game.Town
{
    public class Bar
    {
        private Player player;
        private List<Quest> questList;
        private int currentQuestIndex = 0;

        public Bar(Player player)
        {
            this.player = player;

            // Setup all quests in sequence
            questList = new List<Quest>
            {
                new WolvesQuest("Wolf Hunt", "Kill 3 wolves."),
                new BearsQuest("Bear Hunt", "Kill 2 bears."),
                new VampireQuest("Vampire Hunt", "Kill the vampire miniboss.")
            };
        }

        public void Enter()
        {
            Console.WriteLine("\n--- Bar ---");

            // If the player has no active quest and there are more quests to offer
            if (player.ActiveQuest == null && currentQuestIndex < questList.Count)
            {
                var quest = questList[currentQuestIndex];

                Console.WriteLine($"The shady drunkard approaches you with a quest: {quest.Name}");
                Console.WriteLine($"\"{quest.Description}\"");

                player.ActiveQuest = quest;
                quest.IsTaken = true;

                Console.WriteLine($"Quest Accepted: {quest.Name}");
            }
            // If player is currently doing a quest
            else if (player.ActiveQuest != null && !player.ActiveQuest.IsCompleted)
            {
                Console.WriteLine($"Quest in progress: {player.ActiveQuest.Description}");
                player.ActiveQuest.ShowProgress();
            }
            // If player has completed the current quest
            else if (player.ActiveQuest != null && player.ActiveQuest.IsCompleted)
            {
                player.ActiveQuest.RewardPlayer(player);

                // Fully clear the quest
                player.ActiveQuest = null;

                // Move to the next quest
                currentQuestIndex++;

                // Immediately offer the next quest if available
                if (currentQuestIndex < questList.Count)
                {
                    Console.WriteLine("\nThe shady drunkard seems to have another task for you.");
                }
                else
                {
                    Console.WriteLine("\nThere are no more quests available.");
                }
            }
            else
            {
                Console.WriteLine("The bar is quiet. No more quests available.");
            }
        }
    }
}
