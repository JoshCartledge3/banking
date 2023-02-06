using BankingMainApplication.Services;

namespace BankingMainApplication
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            // Display main menu options
            Console.WriteLine("This is a banking application. Please select a service?");
            Console.WriteLine("Transactions. (1)");
            Console.WriteLine("Accounts. (2)");
            Console.WriteLine("Validation. (3)");
            // Read result
            string? menuDialogResult = Console.ReadLine();

            // Return requested data
            switch (menuDialogResult)
            {
                case "1":
                    TransactionService.GetTransactionDetails();
                    return;
                case "2":
                    AccountService.GetAccountDetails();
                    return;
                case "3":
                    ValidationService.GetValidationDetails();
                    ValidationService.VerifyPersonalAccount();
                    return;
                default:
                    break;
            }
        }
    }
}