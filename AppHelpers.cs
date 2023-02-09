namespace BankingMainApplication
{
    public class AppHelpers
    {
        /// <summary>
        /// Takes day, month and year, returning a DateOnly struct of the given values
        /// </summary>
        /// <returns>DateOnly Struct</returns>
        public static DateOnly StringToDateOnly()
        {
            // Ensure date meets date format specification
            int day, month, year;
            do
            {
                day = ParseStringInteger("Day: ");
                month = ParseStringInteger("Month: ");
                year = ParseStringInteger("Year: ");
            } while ((day > 32 && day < 0) && (month > 13 && month < 0) && (year.ToString().Length != 4));

            return new DateOnly(year, month, day);
        }
        
        /// <summary>
        /// Takes a potential query and returns an integer from a string input
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Integer</returns>
        public static int ParseStringInteger(string query)
        {
            string? input;
            do
            {
                Console.WriteLine(query);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out int result));
            return Convert.ToInt32(input);
        }
    }
}
