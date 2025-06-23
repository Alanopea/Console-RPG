
namespace Game.Root
{
    public static class GameInput
    {
        public static string ReadInput()
        {
            string input = Console.ReadLine();
            Console.WriteLine($"Player's choice: {input}");
            return input;
        }
    }
}
