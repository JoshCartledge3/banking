using BankingMainApplication.Services;

namespace BankingMainApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            // Display main menu options
            Console.WriteLine("This is a banking application. What would you like to do?");
            Console.WriteLine("Transactions (1)");
            Console.WriteLine("Accounts (2)");
            Console.WriteLine("Validation (3)");
            Console.WriteLine("Current Test (4)");
            string? mainMenuDialogResult = Console.ReadLine();

            // Return requested service options
            switch (mainMenuDialogResult)
            {
                case "1":
                    TransactionService.GetTransactionDetails();
                    break;
                case "2":
                    // AccountService.GetAccountDetails();
                    PersonalAccount.CreatePersonalAccount();
                    break;
                case "3":
                    // Perform and display the result of the validation attempt (Test)
                    Console.WriteLine(ValidationService.BasicVerification() ? "Validation Successful" : "Validation Unsuccessful");
                    break;
                default:
                    break;
            }

            // This'll just keep running so it's less annoying than having to constantly run the app
            Console.WriteLine();
            Main(new string[] {"test"});
        }
    }
}