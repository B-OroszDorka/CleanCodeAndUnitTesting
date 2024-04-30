using CourseMagagementSystem.Models;

namespace CourseMagagementSystem.Abstractions.Clients
{
    public interface IFinancialApiClient
    {
        public Task<bool> CheckPaymentStatus(Student student, Course course);
        public Task<bool> MakePayment(Student student, Course course);
    }
}
