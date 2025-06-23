namespace Game.Items.Weapons
{
    public class Knightblade : Weapon
    {
        public Knightblade() : base("Knightblade", price: 150)
        {
            Attacks.Add(new Attack("Double Cut", damage: 14, speed: 16));
            Attacks.Add(new Attack("Guard Breaker", damage: 26, speed: 9, missChance: 0.3));
        }
    }
}
