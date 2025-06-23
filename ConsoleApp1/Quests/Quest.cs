using Game.Entities;

namespace Game.Quests
{
    public abstract class Quest
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsCompleted { get; protected set; } = false;
        public bool IsTaken { get; set; } = false;

        protected Quest(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void TrackProgress(string enemyName);
        public abstract void ShowProgress();
        public abstract void RewardPlayer(Player player);
    }
}
