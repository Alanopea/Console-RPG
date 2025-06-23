namespace Game.Items.Weapons
{
    public class SteelSword : Weapon
    {
        public SteelSword() : base("Steel Sword", price: 50)
        {
            Attacks.Add(new Attack("Fast Slash", damage: 5, speed: 9));
            Attacks.Add(new Attack("Heavy Blow", damage: 15, speed: 3, missChance: 0.3));
        }
    }
}
