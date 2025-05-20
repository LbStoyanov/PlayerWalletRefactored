using PlayerWalletRefactored.Services;

namespace PlayerWalletRefactored
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wallet = new WalletService();
            var game = new GameService();
            var processor = new CommandProcessor(wallet, game);

            Console.WriteLine("Welcome to the player wallet game!");

            while (true)
            {
                Console.Write("Enter command: ");
                var input = Console.ReadLine();

                if (input?.ToLower().Trim() == "exit")
                {
                    Console.WriteLine("Thank you for playing!");
                    break;
                }

                var response = processor.Process(input);
                Console.WriteLine(response);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
