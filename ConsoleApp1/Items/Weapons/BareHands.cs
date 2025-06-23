
namespace Game.Items.Weapons
{
    public class BareHands : Weapon
    {
        public BareHands() : base("Bare Hands", 0)
        {
            BaseDamage = 2;
            Attacks.Add(new Attack("Punch", 2, 15));
            Attacks.Add(new Attack("Kick", 4, 10, 0.3));
        }
    }
}

