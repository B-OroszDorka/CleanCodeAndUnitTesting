using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CourseManagementSystem.Tests.Clients
{
    public class NotificationServiceTest
    {
        private readonly Mock<ILogger<NotificationService>> _loggerMock = new();
        private readonly NotificationService _notificationService;
        private readonly Mock<INotificationClient> _emailClientMock = new Mock<INotificationClient>();
        private readonly Mock<INotificationClient> _pushNotificationMock = new Mock<INotificationClient>();

        public NotificationServiceTest()
        {
            _notificationService = new NotificationService(_emailClientMock.Object, _pushNotificationMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task SendNotification_Success()
        {
            // Arrange            
            var clients = new List<INotificationClient> { _emailClientMock.Object, _pushNotificationMock.Object };
            var message = "Test message";

            _emailClientMock.Setup(x => x.SendNotification(message)).Returns(Task.CompletedTask);
            _pushNotificationMock.Setup(x => x.SendNotification(message)).Returns(Task.CompletedTask);

            // Act
            await _notificationService.SendNotification(message);

            // Assert
            _emailClientMock.Verify(x => x.SendNotification(message), Times.Once);
            _pushNotificationMock.Verify(x => x.SendNotification(message), Times.Once);
        }

        [Fact]
        public async Task SendNotification_ThrowsNotificationException()
        {
            // Arrange
            var clients = new List<INotificationClient> { _emailClientMock.Object, _pushNotificationMock.Object };
            var message = "Test message";
            var expectedException = new Exception("Test exception");

            // Setting up one client to throw exception
            _emailClientMock.Setup(x => x.SendNotification(message)).Throws(expectedException);
            _pushNotificationMock.Setup(x => x.SendNotification(message)).Returns(Task.CompletedTask);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotificationException>(async () => await _notificationService.SendNotification(message));
            Assert.Equal($"Couldn't send notification with the following message: {message}", exception.Message);
            Assert.Equal(expectedException, exception.InnerException);
            _emailClientMock.Verify(x => x.SendNotification(message), Times.Once);
            _pushNotificationMock.Verify(x => x.SendNotification(message), Times.Never);
        }
    }
}
