
namespace Game.Entities.Enemies
{
    public class Enemy
    {
        public string Name { get; }
        public int HP { get; set; }
        public int Speed { get; }
        public int XPReward { get; }
        public List<(string Name, int Damage, int Speed)> Attacks { get; protected set; }

        public Enemy(string name, int hp, int speed, int xpReward, List<(string, int, int)> attacks)
        {
            Name = name;
            HP = hp;
            Speed = speed;
            XPReward = xpReward;
            Attacks = attacks;
        }

        public virtual void Attack(Player player)
        {
            Random rnd = new Random();
            (string Name, int Damage, int Speed) attack;

            if (Attacks.Count >= 2)
            {
                attack = rnd.Next(100) < 60 ? Attacks[0] : Attacks[1];
            }
            else
            {
                attack = Attacks[0];
            }

            int defense = player.GetDefense();
            int finalDamage = Math.Max(attack.Damage - defense, 0);

            Console.WriteLine($"{Name} uses {attack.Name} and deals {finalDamage} damage!");
            player.HP -= finalDamage;
        }
    }
}
