using Microsoft.Win32.SafeHandles;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace BankingMainApplication.Services
{
    public static class AccountService
    {
        // Read 3 databases into variables
        static List<PersonalAccount> db_PersonalAccounts = ReadAllPersonalAccounts();
        static List<BusinessAccount> db_BusinessAccounts = ReadAllBusinessAccounts();
        static List<ISAAccount> db_ISAAccounts = ReadAllISAAccounts();

        public static void GetAccountDetails()
        {
            Console.WriteLine("GetAccountDetails");
        }

        public static void CreateAccountMenu()
        {
            Console.WriteLine("*** CREATE ACCOUNTS ***");
            Console.WriteLine("Select an account to create.");
            Console.WriteLine("Personal Account (1)");
            Console.WriteLine("Business Account (2)");
            Console.WriteLine("ISA Account (3)");

            string? createAccountDialogResponse = Console.ReadLine();

            switch (createAccountDialogResponse)
            {
                case "1":
                    PersonalAccount.CreatePersonalAccount();
                    break;
                case "2":
                    BusinessAccount.CreateBusinessAccount();
                    break;
                case "3":
                    ISAAccount.CreateISAAccount();
                    break;
                default:
                    Console.WriteLine("No option Selected");
                    break;
            }
        }

        #region Making/Reading/Saving Accounts
        public static List<PersonalAccount> ReadAllPersonalAccounts()
        {
            List<PersonalAccount> db_PersonalAccounts = new List<PersonalAccount>();

            if (File.Exists("PersonalAccounts.csv"))
            {
                foreach (string line in File.ReadAllLines("PersonalAccounts.csv"))
                {
                    List<string> list = line.Split(',').ToList();

                    // Create a new instance of a personal account
                    PersonalAccount personalAccount = new PersonalAccount
                    {
                        AccountId = new Guid(list[0]),
                        Forename = list[1],
                        Surname = list[2],
                        DateOfBirth = DateOnly.Parse(list[3]),
                        Balance = Convert.ToInt32(list[4]),
                    };
                    db_PersonalAccounts.Add(personalAccount);
                }
            }
            return db_PersonalAccounts;
        }

        public static List<BusinessAccount> ReadAllBusinessAccounts()
        {
            List<BusinessAccount> db_BusinessAccounts = new List<BusinessAccount>();

            if (File.Exists("BusinessAccounts.csv"))
            {
                foreach (string line in File.ReadAllLines("BusinessAccounts.csv"))
                {
                    List<string> list = line.Split(',').ToList();

                    BusinessAccount businessAccount = new BusinessAccount()
                    {
                        AccountId = new Guid(list[0]),
                        BusinessName = list[1],
                        BusinessType = list[2],
                        RegistryDate = DateOnly.Parse(list[3]),
                        Balance = Convert.ToInt32(list[4])
                    };
                    db_BusinessAccounts.Add(businessAccount);
                }
            }
            return db_BusinessAccounts;
        }

        public static List<ISAAccount> ReadAllISAAccounts()
        {
            List<ISAAccount> db_ISAAccounts = new List<ISAAccount>();

            if (File.Exists("ISAAccounts.csv"))
            {
                foreach (string line in File.ReadAllLines("ISAAccounts.csv"))
                {
                    List<string> list = line.Split(',').ToList();

                    ISAAccount isaAccount = new ISAAccount()
                    {
                        AccountId = new Guid(list[0]),
                        Forename = list[1],
                        Surname = list[2],
                        DateOfBirth = DateOnly.Parse(list[3]),
                        Balance = Convert.ToInt32(list[4])
                    };
                    db_ISAAccounts.Add(isaAccount);
                }
            }
            return db_ISAAccounts;
        }

        /// <summary>
        /// Saves all data to the relative databases
        /// </summary>
        public static void SaveAllDatabaseData()
        {
            // Clear all previous data
            File.Delete("PersonalAccounts.csv");
            File.Delete("BusinessAccounts.csv");
            File.Delete("ISAAccounts.csv");

            using (StreamWriter sw = File.AppendText("PersonalAccounts.csv"))
            {
                foreach (PersonalAccount account in db_PersonalAccounts)
                {
                    sw.WriteLine($"{account.AccountId},{account.Forename}," +
                                 $"{account.Surname},{account.DateOfBirth}," +
                                 $"{account.Balance}");
                }
            }
            using (StreamWriter sw = File.AppendText("BusinessAccounts.csv"))
            {
                foreach (BusinessAccount account in db_BusinessAccounts)
                {
                    sw.WriteLine($"{account.AccountId},{account.BusinessName}," +
                                 $"{account.BusinessType},{account.RegistryDate}," +
                                 $"{account.Balance}");
                }
            }
            using (StreamWriter sw = File.AppendText("ISAAccounts.csv"))
            {
                foreach (ISAAccount account in db_ISAAccounts)
                {
                    sw.WriteLine($"{account.AccountId},{account.Forename}," +
                                 $"{account.Surname},{account.DateOfBirth}," +
                                 $"{account.Balance}");
                }
            }
        }

        public static void CreateNewPersonalAccount(Account account)
        {
            if (account is PersonalAccount) db_PersonalAccounts.Add((PersonalAccount) account);
            if (account is BusinessAccount) db_BusinessAccounts.Add((BusinessAccount) account);
            if (account is ISAAccount) db_ISAAccounts.Add((ISAAccount) account);
        }
        #endregion
    }
}
