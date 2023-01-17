using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingMainApplication
{
    public class Account
    {
        // Requirements
        public const int MinimumDeposit = 1;

        // User information
        public int AccountID;
        public int Balance;
        public string Forename = "";
        public string Surname = "";
        public int DateOfBirth;
    }
}
