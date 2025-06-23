using Game.Entities;

namespace Game.Encounters
{
    public interface IEncounter
    {
        void Execute(Player player);
        bool ExecuteAndReturnIfFled(Player player);
    }
}
