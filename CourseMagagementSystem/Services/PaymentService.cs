using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Abstractions.Services;
using CourseMagagementSystem.Models;
namespace CourseMagagementSystem.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IFinancialApiClient _financialApiClient;

        public PaymentService(IFinancialApiClient financialApiClient)
        {
            _financialApiClient = financialApiClient;
        }

        public async Task<bool> CheckPaymentStatus(Student student, Course course)
        {
            return await _financialApiClient.CheckPaymentStatus(student, course);
        }

        public async Task<bool> MakePayment(Student student, Course course)
        {
            return await _financialApiClient.MakePayment(student, course);
        }
    }
}
