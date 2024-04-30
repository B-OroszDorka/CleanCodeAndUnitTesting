using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Exceptions;
using Microsoft.Extensions.Logging;

namespace CourseMagagementSystem.Clients
{
    public class PushNotificationClient : INotificationClient
    {
        private readonly ILogger<PushNotificationClient> _logger;

        public PushNotificationClient(ILogger<PushNotificationClient> logger)
        {
            _logger = logger;
        }
        public async Task SendNotification(string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    throw new EmailException($"An error occured during sending pushnotification with the following message: {message}");
                }
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured during sending pushnotification with the following message: {message}");
                throw new PushNotificationException($"An error occured during sending pushnotification with the following message: {message}", ex);
            }
        }
    }
}
