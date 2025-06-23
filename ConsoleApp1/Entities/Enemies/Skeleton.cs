
namespace Game.Entities.Enemies
{
    public class Skeleton : Enemy
    {
        public Skeleton() : base(
            "Skeleton",
            30,
            10,
            10,
            new List<(string, int, int)>
            {
                ("Scool", 10, 10),
                ("Bone-er", 7, 12)
            })
        { }
    }
}
