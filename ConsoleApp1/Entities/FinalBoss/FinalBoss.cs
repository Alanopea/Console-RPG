using Game.Entities.Enemies;
using Game.Entities;

namespace Game.Entities.FinalBoss
{
    public class FinalBoss : Enemy
    {
        private List<string> Phases { get; }
        private int CurrentPhaseIndex;

        public FinalBoss(string name, int hp, int speed, int xpReward, List<(string, int, int)> attacks)
            : base(name, hp, speed, xpReward, attacks)
        {
            Phases = new List<string> { "Fire", "Shadow", "Death" };
            CurrentPhaseIndex = 0;
        }

        public override void Attack(Player player)
        {
            var attack = Attacks[new Random().Next(Attacks.Count)];
            int defense = player.GetDefense();
            int finalDamage = Math.Max(attack.Damage - defense, 0);

            Console.WriteLine($"{Name} unleashes {attack.Name} and deals {finalDamage} damage!");
            player.HP -= finalDamage;
        }

        public void CheckPhaseTransition()
        {
            if (HP <= 100 && CurrentPhaseIndex == 0)
            {
                CurrentPhaseIndex = 1;
                EnterPhase("Shadow", new List<(string, int, int)>
                {
                    ("Shadow Barrage", 30, 4),
                    ("Dark Pulse", 20, 6)
                });
            }
            else if (HP <= 50 && CurrentPhaseIndex == 1)
            {
                CurrentPhaseIndex = 2;
                EnterPhase("Death", new List<(string, int, int)>
                {
                    ("Death's Grasp", 35, 5),
                    ("Void Implosion", 40, 3)
                });
            }
        }

        private void EnterPhase(string phaseName, List<(string, int, int)> newAttacks)
        {
            Console.WriteLine($"\n{Name} roars and transforms into the {phaseName} phase!");
            Console.WriteLine($"His attacks change!\n");
            Attacks = newAttacks;
        }

        public static FinalBoss Create()
        {
            return new FinalBoss(
                name: "Lord Malgar",
                hp: 150,
                speed: 5,
                xpReward: 100,
                attacks: new List<(string, int, int)>
                {
                    ("Firestorm", 20, 5),
                    ("Blazing Slash", 15, 7)
                }
            );
        }
    }
}
