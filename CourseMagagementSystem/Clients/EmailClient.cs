using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Exceptions;
using Microsoft.Extensions.Logging;

namespace CourseMagagementSystem.Clients
{
    public class EmailClient : INotificationClient
    {
        private readonly ILogger<EmailClient> _logger;

        public EmailClient(ILogger<EmailClient> logger)
        {
            _logger = logger;
        }

        public async Task SendNotification(string message)
        {
            try
            {
                if(string.IsNullOrEmpty(message))
                {
                    throw new EmailException($"An error occured during sending Email notification with the following message: {message}");
                }
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured during sending Email notification with the following message: {message}");
                throw new EmailException($"An error occured during sending Email notification with the following message: {message}", ex);
            }
        }
    }
}
