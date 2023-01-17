namespace BankingMainApplication
{
    public class Account
    {
        // Requirements
        public const int MinimumDeposit = 1;

        // User Information
        public int AccountId { get; set; }
        public int Balance { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
