
namespace Game.Entities.Enemies
{
    public class Bear : Enemy
    {
        public Bear() : base(
            "Bear",
            50,
            5,
            20,
            new List<(string, int, int)>
            {
                ("Swipe", 10, 5),
                ("Slam", 15, 3)
            })
        { }
    }
}
