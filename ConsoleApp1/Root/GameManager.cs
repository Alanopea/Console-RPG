using Game.Entities;
using Game.Entities.FinalBoss;
using Game.Items.Weapons;
using Game.Menus;
using Game.States;


namespace Game.Root
{
    public class GameManager
    {
        public TownState TownState { get; private set; }
        public Player Player { get; private set; }
        private IState currentState;

        private readonly MainMenu mainMenu = new MainMenu();
        private readonly DeathScreen deathScreen = new DeathScreen();
        private readonly GameEnding gameEnding = new GameEnding();

        public void Start()
        {
            Run();
        }

        public void Run()
        {
            while (true)
            {
                mainMenu.Show();
                StartGameLoop();
            }
        }

        public GameManager()
        { }

        private void InitializeStartingWeapon()
        {
            var starter = new BareHands();
            Player.Inventory.Add(starter);
            Player.EquippedWeapon = starter;
            Console.WriteLine($"Equipped starting weapon: {starter.Name}");
        }

        private void StartGameLoop()
        {
            Player = new Player("Hero", 100);
            InitializeStartingWeapon();
            TownState = new TownState(this);

            for (int day = 1; day <= 20; day++)
            {
                Console.WriteLine($"\n--- Day {day} ---");

                bool validChoice = false;

                while (!validChoice)
                {
                    Console.WriteLine("Choose an action:\n1. Enter Dungeon\n2. Rest\n3. Visit Town");
                    var input = GameInput.ReadInput();

                    switch (input)
                    {
                        case "1":
                            currentState = new DungeonState(this);
                            validChoice = true;
                            break;
                        case "2":
                            currentState = new RestState(this);
                            validChoice = true;
                            break;
                        case "3":
                            currentState = TownState;
                            validChoice = true;
                            break;
                        default:
                            Console.WriteLine("Invalid input, please pick a correct option (1, 2 or 3).");
                            break;
                    }
                }

                currentState.Execute();

                if (Player.HP <= 0)
                {
                    deathScreen.Show();
                    return;
                }
            }

            var boss = FinalBoss.Create();
            var bossEncounter = new Encounters.CombatEncounter(Player, boss);

            while (boss.HP > 0 && Player.HP > 0 && !bossEncounter.PlayerFled)
            {
                bossEncounter.Execute(Player);

                if (boss.HP > 0)
                {
                    boss.CheckPhaseTransition();
                }
            }

            if (Player.HP <= 0)
            {
                deathScreen.Show();
            }
            else if (bossEncounter.PlayerFled)
            {
                deathScreen.Show();
            }
            else
            {
                gameEnding.Show();
            }
        }
    }
}
