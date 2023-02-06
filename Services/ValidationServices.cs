namespace BankingMainApplication.Services
{
    public static class ValidationService
    {
        public static void GetValidationDetails()
        {
            Console.WriteLine("GetValidationDetails");
        }

        #region Account Verification

        /// <summary>
        /// The three basic checks we perform on every account verification
        /// </summary>
        /// <returns>Returns true if all checks are successful</returns>
        private static bool BasicVerification()
        {
            bool verificationResult;
            string[] basicCheckResults = new string[3];

            /// Perform checks
            Console.WriteLine("Does the applicant have a valid photo ID? [Y/N]");
            basicCheckResults[0] = Console.ReadLine().ToLower();
            Console.WriteLine("Does the applicant have a valid address based ID? [Y/N]");
            basicCheckResults[1] = Console.ReadLine().ToLower();
            Console.WriteLine("Has the applicant provided the minimum deposit fee of £1.00 [Y/N]");
            basicCheckResults[2] = Console.ReadLine().ToLower();

            // Compare the results with a successful result
            verificationResult = basicCheckResults.SequenceEqual(new string[] {"y", "y", "y"});
            return verificationResult;
        }

        /// <summary>
        /// Verification process for a customer who is attempting to open a personal account
        /// </summary>
        /// <returns>True if the account is verified, else false</returns>
        public static bool VerifyPersonalAccount()
        {
            bool accountVerified = false;
            Console.WriteLine("Personal account verification");

            BasicVerification();
            return accountVerified;
        }

        /// <summary>
        /// Verification process for a customer who is attempting to open a ISA account
        /// </summary>
        /// <returns>True if the account is verified, else false</returns>
        public static bool VerifyISAAccount()
        {
            bool accountVerified = false;
            Console.WriteLine("ISA account verification");

            BasicVerification();
            return accountVerified;
        }

        /// <summary>
        /// Verification process for a customer who is attempting to open a business account
        /// </summary>
        /// <returns>True if the account is verified, else false</returns>
        public static bool VerifyBusinessAccount()
        {
            bool accountVerified = false;
            Console.WriteLine("Business account verification");

            BasicVerification();
            return accountVerified;
        }
        #endregion
    }
}
