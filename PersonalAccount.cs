
using BankingMainApplication.Services;

namespace BankingMainApplication
{
    public class PersonalAccount : Account
    {
        // Standard customer account attributes
        public const int DailyOverdraftFee = 5;

        /// <summary>
        /// Creates a new instance of a personal account
        /// </summary>
        public static void CreatePersonalAccount()
        {
            // Prompt user for customer information and save values
            Console.Write("Customer Forename: ");
            string? forename = Console.ReadLine();
            Console.Write("Customer Surname: ");
            string? surname = Console.ReadLine();

            double initialDeposit;
            do
            {
                Console.Write("Initial Deposit: £");
                double.TryParse(Console.ReadLine(), out initialDeposit);
            } while (initialDeposit.GetType().ToString() == "double");

            Console.WriteLine("-- Date of birth --");
            DateOnly dateOfBirth = AppHelpers.StringToDateOnly();

            // Create a new instance of a personal account
            Account newPersonalAccount = new Account
            {
                AccountId = Guid.NewGuid().ToString(),
                Balance = initialDeposit,
                Forename = forename,
                Surname = surname,
                DateOfBirth = dateOfBirth
            };

            if (newPersonalAccount.Balance < MinimumDeposit) errorList.Add(1);
            if (string.IsNullOrWhiteSpace(newPersonalAccount.Forename)) errorList.Add(2);
            if (string.IsNullOrWhiteSpace(newPersonalAccount.Surname)) errorList.Add(3);
            if (!ValidationService.BasicVerification()) errorList.Add(4);


            // If the object is complete, verify the user and write their account to CSV
            if (errorList.Count == 0 && ValidationService.BasicVerification())
            {
                using (StreamWriter sw = File.AppendText("PersonalAccounts.csv"))
                {
                    sw.WriteLine($"{newPersonalAccount.AccountId}, {newPersonalAccount.Forename}," +
                                 $"{newPersonalAccount.Surname}, {newPersonalAccount.DateOfBirth}, " +
                                 $"{newPersonalAccount.Balance}");
                }
                Console.WriteLine("Account creation successful.");
            }
            // Otherwise, do not create account and display the error
            else
            {
                Console.WriteLine("** Account creation failed **");
                foreach (var error in errorList)
                {
                    switch (error)
                    {
                        case 1:
                            Console.WriteLine("- Initial deposit was less than £1.00.");
                            break;
                        case 2:
                            Console.WriteLine("- No forename was entered.");
                            break;
                        case 3:
                            Console.WriteLine("- No surname was entered.");
                            break;
                        case 4:
                            Console.WriteLine("- Invalid/No ID was presented.");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}