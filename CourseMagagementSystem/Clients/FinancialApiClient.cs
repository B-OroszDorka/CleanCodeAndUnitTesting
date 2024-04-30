using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Models;
using Microsoft.Extensions.Logging;

namespace CourseMagagementSystem.Clients
{
    public class FinancialApiClient : IFinancialApiClient
    {
        private readonly ILogger<FinancialApiClient> _logger;

        public FinancialApiClient(ILogger<FinancialApiClient> logger)
        {
            _logger = logger;
        }
        public async Task<bool> CheckPaymentStatus(Student student, Course course)
        {
            var studentName = "";
            try
            {
                if(student == null || course == null)
                {
                    throw new PaymentException($"An error occured while checking payment status of the following student: {studentName}");
                }
                studentName = student.GetName();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while checking payment status of the following student: {studentName}");
                throw new PaymentException($"An error occured while checking payment status of the following student: {studentName}", ex);
            }
        }

        public async Task<bool> MakePayment(Student student, Course course)
        {
            var studentName = "";
            try
            {
                if (student == null || course == null)
                {
                    throw new PaymentException($"An error occured while making payment of the following student: {studentName}");
                }
                studentName = student.GetName();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while making payment of the following student: {studentName}");
                throw new PaymentException($"An error occured while making payment of the following student: {studentName}", ex);
            }
        }
    }
}
