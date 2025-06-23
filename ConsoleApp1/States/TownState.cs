using Game.Root;
using Game.Town;


namespace Game.States
{
    public class TownState : IState
    {
        private readonly GameManager manager;
        private readonly Market market;
        private readonly Church church;
        private readonly Bar bar;

        public TownState(GameManager manager)
        {
            this.manager = manager;
            this.market = new Market(manager.Player);
            this.church = new Church(manager.Player);
            this.bar = new Bar(manager.Player);
        }

        public void Execute()
        {
            bool inTown = true;

            while (inTown)
            {
                Console.WriteLine("\nYou are in the town. Where would you like to go?");
                Console.WriteLine("1. Market");
                Console.WriteLine("2. Church");
                Console.WriteLine("3. Bar");
                Console.WriteLine("4. Leave town and end the day");

                string input = GameInput.ReadInput();

                switch (input)
                {
                    case "1":
                        market.Enter();
                        break;
                    case "2":
                        church.Enter();
                        break;
                    case "3":
                        bar.Enter();
                        break;
                    case "4":
                        inTown = false;
                        Console.WriteLine("You leave the town and end the day.");
                        break;
                    default:
                        Console.WriteLine("Invalid input, please pick a correct option (1-4).");
                        break;
                }
            }
        }
    }
}
