
using System.Text;

namespace BankingMainApplication
{
    public class Account
    {
        // Requirements
        public const double MinimumDeposit = 1.00;

        // User Information
        public string AccountId { get; set; }
        public double Balance { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
