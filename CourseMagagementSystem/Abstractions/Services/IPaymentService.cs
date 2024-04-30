using CourseMagagementSystem.Models;

namespace CourseMagagementSystem.Abstractions.Services
{
    public interface IPaymentService
    {
        public Task<bool> CheckPaymentStatus(Student student, Course course);
        public Task<bool> MakePayment(Student student, Course course);
    }
}
