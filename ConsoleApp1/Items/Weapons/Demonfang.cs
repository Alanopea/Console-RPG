namespace Game.Items.Weapons
{
    public class Demonfang : Weapon
    {
        public Demonfang() : base("Demonfang", price: 350)
        {
            Attacks.Add(new Attack("Razor Snap", damage: 20, speed: 18));
            Attacks.Add(new Attack("Soul Crusher", damage: 35, speed: 12, missChance: 0.3));
        }
    }
}