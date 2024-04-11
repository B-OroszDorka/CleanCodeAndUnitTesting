using Moq;
using Xunit;
using static ComplexUnitTestingHomeworkWeek2.CustomCurrencyException;
using Snapper;

namespace ComplexUnitTestingHomeworkWeek2
{

    public class CurrencyConverterTests
    {
        [Fact]
        public void Convert_ValidInput_ReturnsCorrectAmount()
        {
            // Arrange
            var amount = 100;
            var fromCurrency = "USD";
            var toCurrency = "EUR";
            var exchangeRate = 0.85;

            var exchangeRateServiceMock = new Mock<IExchangeRateService>();
            exchangeRateServiceMock.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Returns(exchangeRate);

            var currency = new Currency(amount, exchangeRateServiceMock.Object);

            // Act
            var result = currency.Convert(amount, fromCurrency, toCurrency);

            // Assert
            var expected = 120;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Convert_InvalidInput_ThrowsException()
        {
            // Arrange
            var amount = 100;
            var exchangeRateServiceMock = new Mock<IExchangeRateService>();

            var currency = new Currency(amount, exchangeRateServiceMock.Object);

            // Act and Assert
            Assert.Throws<CustomCurrencyConverterException>(() => currency.ValidateAmount(double.NaN));
        }

        [Fact]
        public void Convert_ErrorFromExchangeRateService_ThrowsException()
        {
            // Arrange
            var amount = 100;
            var exchangeRateServiceMock = new Mock<IExchangeRateService>();
            exchangeRateServiceMock.Setup(x => x.GetExchangeRate(It.IsAny<string>(), It.IsAny<string>())).Throws(new ExchangeRateNotFoundException("Exchange rate not found"));

            var currency = new Currency(amount, exchangeRateServiceMock.Object);

            // Act and Assert
            Assert.Throws<ExchangeRateNotFoundException>(() => currency.GetExchangeRate("HUF", "EUR"));
        }

        [Fact]
        public void Convert_SnapshotTest()
        {
            // Arrange
            var amount = 100;
            var fromCurrency = "USD";
            var toCurrency = "EUR";
            var exchangeRate = 0.85;

            var exchangeRateServiceMock = new Mock<IExchangeRateService>();
            exchangeRateServiceMock.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Returns(exchangeRate);

            var currency = new Currency(amount, exchangeRateServiceMock.Object);

            // Act
            var result = currency.Convert(amount, fromCurrency, toCurrency);

            result.ShouldMatchSnapshot();
        }
    }
    public class CurrencyReportTests
    { 
        [Fact]
        public void GenerateConversionReport_ValidInput_ReturnsReport()
        {
            // Arrange
            string fromCurrency = "USD";
            string toCurrency = "EUR";
            DateTime startDate = new DateTime(2022, 1, 1);
            DateTime endDate = new DateTime(2022, 1, 3);
            double exchangeRate = 0.85;

            var exchangeRateServiceMock = new Mock<IExchangeRateService>();
            exchangeRateServiceMock.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Returns(exchangeRate);

            var currency = new Currency(100, exchangeRateServiceMock.Object);

            // Act
            string result = currency.GenerateConversionReport(fromCurrency, toCurrency, startDate, endDate);

            // Assert
            string expected = "Conversion Report:\n120\n120\n120";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GenerateConversionReport_InvalidInput_ThrowsException()
        {
            // Arrange
            var amount = 100;
            string fromCurrency = "USD";
            string toCurrency = "EUR";
            DateTime startDate = new DateTime(2022, 1, 1);
            DateTime endDate = new DateTime(2022, 1, 3);
            var exchangeRate = double.NaN;

            var exchangeRateServiceMock = new Mock<IExchangeRateService>();
            exchangeRateServiceMock.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Throws(new ExchangeRateNotFoundException("Exchange rate not found"));

            var currency = new Currency(amount, exchangeRateServiceMock.Object);

            // Act and Assert
            Assert.Throws<CustomCurrencyConverterException>(() =>Currency.ValidateExchangeRate(exchangeRate));
        }

        [Fact]
        public void GenerateConversionReport_SnapshotTest()
        {
            // Arrange
            var amount = 100;
            string fromCurrency = "USD";
            string toCurrency = "EUR";
            DateTime startDate = new DateTime(2022, 1, 1);
            DateTime endDate = new DateTime(2022, 1, 3);
            double exchangeRate = 1.2;

            var exchangeRateServiceMock = new Mock<IExchangeRateService>();
            exchangeRateServiceMock.Setup(x => x.GetExchangeRate(fromCurrency, toCurrency)).Returns(exchangeRate);

            var currency = new Currency(amount, exchangeRateServiceMock.Object);

            // Act
            string result = currency.GenerateConversionReport(fromCurrency, toCurrency, startDate, endDate);

            result.ShouldMatchSnapshot();
        }
    }
}