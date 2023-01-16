using BankingMainApplication.Services;

namespace BankingMainApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;


            Console.WriteLine("This is a banking application.");

            TransactionService.GetTransactionDetails();
            AccountService.GetAccountDetails();
            ValidationService.GetValidationDetails();
        }

    }
}