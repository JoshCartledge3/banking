
using BankingMainApplication.Services;
using System.Diagnostics.CodeAnalysis;

namespace BankingMainApplication
{
    public class ISAAccount : Account
    {
        // Standard ISA Account attributes
        // Residential Status
        public bool ResidentOrCrownServant { get; set; }

        // Age conditions
        public const int MinimumAge = 18;
        public const int MaximumAge = 40;

        // Interest and Bonus rates
        public const float InterestRate = 2.7f;
        public const float EarlyWithdrawalFee = 0.25f;
        public const float AnnualBonus = 0.25f;

        // Accepted withdrawal conditions
        public string[] AcceptedWithdrawalConditions = { "Terminal", "Retirement", "First Home" };

        /// <summary>
        /// Creates a new ISA Account
        /// </summary>
        public static void CreateISAAccount()
        {
            // Check for an existing account to pull some values from
            Console.Write("Does the applicant already have a personal account? [Y/N]: ");
            bool hasPersonalAccount = Console.ReadLine().ToLower() == "y" ? true: false;

            ISAAccount newISAAccount = new ISAAccount();
            string[] dob = new string [3];

            if (hasPersonalAccount)
            {
                Console.Write("Enter account ID: ");
                string accountID = Console.ReadLine();

                try // to read the file
                {
                    // Find the account
                    foreach (var account in File.ReadAllLines("PersonalAccounts.csv"))
                    {
                        
                        if (accountID == account.Split(',')[0])
                        {
                            // Store the values
                            List<string> values = account.Split(',').ToList();
                            dob = values[3].Split("/");

                            // Set values
                            newISAAccount.AccountId = Guid.NewGuid();
                            newISAAccount.Forename = values[1];
                            newISAAccount.Surname = values[2];
                            newISAAccount.DateOfBirth = new DateOnly(Convert.ToInt32(dob[2]), Convert.ToInt32(dob[1]), Convert.ToInt32(dob[1]));
                            newISAAccount.Balance = 0;
                            break;
                        }
                    Console.WriteLine("Account not found.");
                    }
                }
                catch
                {
                    Console.WriteLine("Database not found.");
                }
            }

            // If we dont already have a current account to pull data from, request it from customer
            else
            {
                newISAAccount.AccountId = Guid.NewGuid();
                Console.Write("Customer Forename: ");
                newISAAccount.Forename = Console.ReadLine();
                Console.Write("Customer Surname: ");
                newISAAccount.Surname = Console.ReadLine();
                Console.WriteLine("-- Date of birth --");
                newISAAccount.DateOfBirth = AppHelpers.StringToDateOnly();
            }

            // Get residential status
            Console.Write("Is the applicant a UK resident or crown servant? [Y/N]: ");
            newISAAccount.ResidentOrCrownServant = Console.ReadLine().ToLower() == "y" ? true : false;

            // Calculate age
            int age;
            age = DateTime.Now.Year - newISAAccount.DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < newISAAccount.DateOfBirth.DayOfYear) age = age - 1;

            // Perform checks
            List<int> errorList = new();

            if (!newISAAccount.ResidentOrCrownServant) errorList.Add(1);
            if (18 > age || age > 41) errorList.Add(2);
            if (!ValidationService.BasicVerification()) errorList.Add(3);

            try // to read the file
            {
                // Tru find the account
                foreach (var account in File.ReadAllLines("ISAAccounts.csv"))
                {

                    if (account.Contains(newISAAccount.Forename) && account.Contains(newISAAccount.Forename) && account.Contains(newISAAccount.DateOfBirth.ToString()))
                    {
                        Console.Write("A user with this name and date of birth already exists, is this a duplicate account? [Y/N]");
                        bool response = Console.ReadLine().ToLower() == "y";
                        if (response) errorList.Add(4);
                    }
                }
            }
            catch
            {
                // Do nothing
            }

            // If the object is complete, verify the business and write their account to CSV
            if (errorList.Count == 0)
            {
                using (StreamWriter sw = File.AppendText("ISAAccounts.csv"))
                {
                    sw.WriteLine($"{newISAAccount.AccountId},{newISAAccount.Forename}," +
                                 $"{newISAAccount.Surname},{newISAAccount.DateOfBirth}," +
                                 $"{newISAAccount.Balance}");
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
                            Console.WriteLine("- Customer must be a UK resident or crown servant to open an ISA account.");
                            break;
                        case 2:
                            Console.WriteLine("- Customer must be between 18 and 40 to open an ISA account.");
                            break;
                        case 3:
                            Console.WriteLine("- Invalid/No ID presented.");
                            break;
                        case 4:
                            Console.WriteLine("- Customers may only have one ISA account.");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
