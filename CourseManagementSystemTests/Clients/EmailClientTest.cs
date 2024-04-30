using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Clients;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CourseManagementSystemTests.Clients
{
    public class EmailClientTest
    {
        private readonly Mock<ILogger<EmailClient>> _loggerMock = new();
        private readonly EmailClient _notificationService;

        public EmailClientTest()
        {
            _notificationService = new EmailClient(_loggerMock.Object);
        }

        [Fact]
        public async Task SendNotification_Success()
        {
            // Arrange
            var message = "Test message";

            // Act
            await _notificationService.SendNotification(message);

            // Assert
            // Since Console.WriteLine doesn't return anything and doesn't throw exceptions,
            // we can't verify the actual sending. We can just verify that the method didn't throw an exception.
        }

        [Fact]
        public async Task SendNotification_ThrowsEmailException()
        {
            // Arrange
            string message = null;
            var expectedException = new EmailException("Test exception");

            // Act & Assert
            await Assert.ThrowsAsync<EmailException>(async () => await _notificationService.SendNotification(message));
        }
    }
}
