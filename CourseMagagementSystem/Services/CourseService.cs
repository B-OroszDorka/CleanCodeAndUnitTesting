using CourseMagagementSystem.Abstractions.Repository;
using CourseMagagementSystem.Abstractions.Services;
using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Models;
using Microsoft.Extensions.Logging;

namespace CourseMagagementSystem.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IPaymentService _paymentService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<CourseService> _logger;
        public CourseService(ICourseRepository courseRepository, IPaymentService paymentService, INotificationService notificationService, ILogger<CourseService> logger)
        {
            _courseRepository = courseRepository;
            _paymentService = paymentService;
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task<Course> GetCourseById(string courseId)
        {
            return await _courseRepository.GetCourseById(courseId);
        }
        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAllCourses();
        }
        public async Task AddCourse(Course course)
        {
            await _courseRepository.AddCourse(course);
        }       
        public async Task AddStudentToCourse(Student student, Course course)
        {
            var studentName = student.GetName();
            var courseId = course.GetId();

            var paymentStatus = await CheckPaymentStatus(student, course);
            if (!paymentStatus)
            {
                _logger.LogError("Payment not completed.");
                throw new PaymentException("Payment not completed.");
            }

            await _courseRepository.AddStudentToCourse(student, course);
            await _notificationService.SendNotification($"Student {studentName} has been added to course {courseId}");
        }

        private async Task<bool> CheckPaymentStatus(Student student, Course course)
        {
            return await _paymentService.CheckPaymentStatus(student, course);
        }
    }
}
