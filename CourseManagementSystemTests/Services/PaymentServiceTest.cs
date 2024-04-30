using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Abstractions.Services;
using CourseMagagementSystem.Models;
using CourseMagagementSystem.Services;
using Moq;
using Xunit;

namespace CourseMagagementSystem.Tests.Services
{
    public class PaymentServiceTest
    {
        private readonly Mock<IFinancialApiClient> _financialApiClientMock = new();
        private readonly IPaymentService _paymentService;

        public PaymentServiceTest()
        {
            _paymentService = new PaymentService(_financialApiClientMock.Object);
        }

        [Fact]
        public async Task CheckPaymentStatus_Success()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();
            _financialApiClientMock.Setup(x => x.CheckPaymentStatus(student, course)).ReturnsAsync(true);

            // Act
            var result = await _paymentService.CheckPaymentStatus(student, course);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CheckPaymentStatus_Failure()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();
            _financialApiClientMock.Setup(x => x.CheckPaymentStatus(student, course)).ReturnsAsync(false);

            // Act
            var result = await _paymentService.CheckPaymentStatus(student, course);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task MakePayment_Success()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();
            _financialApiClientMock.Setup(x => x.MakePayment(student, course)).ReturnsAsync(true);

            // Act
            var result = await _paymentService.MakePayment(student, course);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task MakePayment_Failure()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();
            _financialApiClientMock.Setup(x => x.MakePayment(student, course)).ReturnsAsync(false);

            // Act
            var result = await _paymentService.MakePayment(student, course);

            // Assert
            Assert.False(result);
        }
    }
}
