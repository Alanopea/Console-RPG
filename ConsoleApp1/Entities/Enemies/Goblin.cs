
namespace Game.Entities.Enemies
{
    public class Goblin : Enemy
    {
        public Goblin() : base(
            "Goblin",
            35,
            10,
            12,
            new List<(string, int, int)>
            {
                ("Slash", 12, 10),
                ("Rage", 15, 8)
            })
        { }
    }
}
