using CourseMagagementSystem.Clients;
using CourseMagagementSystem.Models;
using CourseMagagementSystem.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CourseManagementSystemTests.Clients
{
    public class FinancialApiClientTest
    {
        private readonly Mock<ILogger<FinancialApiClient>> _loggerMock = new();
        private readonly FinancialApiClient _paymentService;

        public FinancialApiClientTest()
        {
            _paymentService = new FinancialApiClient(_loggerMock.Object);
        }

        [Fact]
        public async Task CheckPaymentStatus_Success()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();

            // Act
            var result = await _paymentService.CheckPaymentStatus(student, course);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CheckPaymentStatus_IfCourseNull_ThrowsPaymentException()
        {
            // Arrange
            var student = new Student("John Doe");

            // Act & Assert
            await Assert.ThrowsAsync<PaymentException>(async () => await _paymentService.CheckPaymentStatus(student, null));
        }

        [Fact]
        public async Task CheckPaymentStatus_IfStudentNull_ThrowsPaymentException()
        {
            // Arrange
            var course = new Course();

            // Act & Assert
            await Assert.ThrowsAsync<PaymentException>(async () => await _paymentService.CheckPaymentStatus(null, course));
        }

        [Fact]
        public async Task MakePayment_Success()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();

            // Act
            var result = await _paymentService.MakePayment(student, course);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task MakePayment_IfCourseNull_ThrowsPaymentException()
        {
            // Arrange
            var student = new Student("John Doe");

            // Act & Assert
            await Assert.ThrowsAsync<PaymentException>(async () => await _paymentService.MakePayment(student, null));
        }

        [Fact]
        public async Task MakePayment_IfStudentNull_ThrowsPaymentException()
        {
            // Arrange
            var course = new Course();

            // Act & Assert
            await Assert.ThrowsAsync<PaymentException>(async () => await _paymentService.MakePayment(null, course));
        }
    }
}
