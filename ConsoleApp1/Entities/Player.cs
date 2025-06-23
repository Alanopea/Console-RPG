using Game.Inventory;
using Game.Items;
using Game.Items.Armour;
using Game.Items.Weapons;
using Game.Quests;

namespace Game.Entities
{
    public class Player
    {
        public string Name { get; }
        public int HP { get; set; }
        public int MaxHP { get; private set; }
        public int Gold { get; set; } = 200;
        public int XP { get; set; }
        public int Speed { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armour EquippedArmour { get; set; }
        public List<Item> Inventory { get; }
        public Bag Bag { get; set; }
        public Quest ActiveQuest { get; set; }

        public Player(string name, int maxHp)
        {
            Name = name;
            MaxHP = maxHp;
            HP = maxHp;
            XP = 0;
            Speed = 10;
            Inventory = new List<Item>();
            Bag = new Bag();
        }

        public void UseItem(Item item)
        {
            item.Use(this);
        }

        public int GetDefense()
        {
            return EquippedArmour?.Defense ?? 0;
        }

        public bool HasBloodbending { get; set; } = false;

        public void IncreaseMaxHP(int amount)
        {
            MaxHP += amount;
        }

        public void HealAfterAttack()
        {
            if (HasBloodbending)
            {
                HP += 5;
                Console.WriteLine("Bloodbending Talisman heals you for 5 HP.");
            }
        }
        public bool Betray { get; set; } = false;
    }
}