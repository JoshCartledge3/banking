namespace BankingMainApplication
{
    public class Account
    {
        // Requirements
        public const int MinimumDeposit = 1;

        // User Information
        public Guid AccountId { get; set; }
        public double Balance { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }

        #region Account Methods

        /// <summary>
        /// Displays a customer's account details
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="accountType"></param>
        /// <returns>String array of a customer's account detials</returns>
        public static string[] ViewAccount(string accountID, string accountType)
        {
            try
            {
                foreach (var account in File.ReadAllLines(accountType + ".csv"))
                {
                    if (account.Contains(accountID)) return account.Trim().Split(',');
                }
                return new string[] { "No account found." };
            }
            catch
            {
                return new string[] { "Database could not be reached." };
            }
        }

        #endregion
    }
}
