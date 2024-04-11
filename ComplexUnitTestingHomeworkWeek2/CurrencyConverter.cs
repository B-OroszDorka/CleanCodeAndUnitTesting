using static ComplexUnitTestingHomeworkWeek2.CustomCurrencyException;

namespace ComplexUnitTestingHomeworkWeek2
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyConverter.Execute();
        }
    }

    public class CurrencyConverter
    {
        // Fixed amount used for conversion
        private static readonly int _fixedAmount = 100;
        static IExchangeRateService _exchangeRateService;

        public CurrencyConverter(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public static void Execute()
        {
            double amount;
            var isValidInput = false;            

            do
            {
                Console.WriteLine("Give the amount to convert: ");
                var amountToConvert = Console.ReadLine();

                if (double.TryParse(amountToConvert, out amount))
                {
                    isValidInput = true; // Set flag to exit loop
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!isValidInput);

            var fromCurrency = "USD";
            var toCurrency = "EUR";

            var currency = new Currency(_fixedAmount, _exchangeRateService);

            try
            {
                var validatedAmount = currency.ValidateAmount(amount);
                var convertedAmount = currency.Convert(amount, fromCurrency, toCurrency);
                Console.WriteLine($"Converted amount: {convertedAmount}");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            catch (CustomCurrencyConverterException ex)
            {
                throw new CustomCurrencyConverterException($"An error occured during the conversion: {ex.Message}");
            }

            // Generate a conversion report for a specified period
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 5);
            try
            {
                var conversionReport = currency.GenerateConversionReport(fromCurrency, toCurrency, startDate, endDate);
                Console.WriteLine($"The conversion report from 1.1.2024 to 5.1.2024: {conversionReport}");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            catch (CustomCurrencyConverterException ex)
            {
                Console.WriteLine($"Error generating conversion report: {ex.Message}");
            }
        }
    }    
}
