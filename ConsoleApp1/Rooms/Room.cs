using Game.Encounters;

namespace Game.Rooms
{
    public class Room
    {
        public IEncounter Encounter { get; }

        public Room(IEncounter encounter)
        {
            Encounter = encounter;
        }
    }
}
