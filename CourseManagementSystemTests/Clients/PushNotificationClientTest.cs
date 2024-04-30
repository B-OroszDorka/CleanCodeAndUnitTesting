using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Clients;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CourseManagementSystemTests.Clients
{
    public class PushNotificationClientTest
    {
        private readonly Mock<ILogger<PushNotificationClient>> _loggerMock = new();
        private readonly PushNotificationClient _notificationService;

        public PushNotificationClientTest()
        {
            _notificationService = new PushNotificationClient(_loggerMock.Object);
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
            var expectedException = new PushNotificationException("Test exception");

            // Act & Assert
            await Assert.ThrowsAsync<PushNotificationException>(async () => await _notificationService.SendNotification(message));
        }
    }
}
