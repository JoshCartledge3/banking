using BankingMainApplication.Services;

namespace BankingMainApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Loading(5);
            Console.WriteLine("This is a banking application.");
            TransactionService.GetTransactionDetails();
            AccountService.GetAccountDetails();
            ValidationService.GetValidationDetails();
        }
        
        private static void Loading(int time)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Loading");
            for (var i = 0; i < time; i++)
            {
                Task.Delay(300);
                Console.WriteLine(".");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}