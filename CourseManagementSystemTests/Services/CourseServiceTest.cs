using CourseMagagementSystem.Abstractions.Repository;
using CourseMagagementSystem.Abstractions.Services;
using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Models;
using CourseMagagementSystem.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CourseManagementSystemTests.Services
{
    public class CourseServiceTest
    {
        private readonly Mock<ICourseRepository> _courseRepositoryMock = new();
        private readonly Mock<IPaymentService> _paymentServiceMock = new();
        private readonly Mock<INotificationService> _notificationServiceMock = new();
        private readonly Mock<ILogger<CourseService>> _loggerMock = new();
        private readonly ICourseService _courseService;

        public CourseServiceTest()
        {
            _courseService = new CourseService(_courseRepositoryMock.Object, _paymentServiceMock.Object, _notificationServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetCourseById_Success()
        {
            // Arrange
            string courseId = "123";
            Course expectedCourse = new Course();

            _courseRepositoryMock.Setup(x => x.GetCourseById(courseId)).ReturnsAsync(expectedCourse);

            // Act
            var result = await _courseService.GetCourseById(courseId);

            // Assert
            Assert.Same(expectedCourse, result);
        }

        [Fact]
        public async Task GetAllCourses_Success()
        {
            // Arrange
            List<Course> expectedCourses = new List<Course>();

            _courseRepositoryMock.Setup(x => x.GetAllCourses()).ReturnsAsync(expectedCourses);

            // Act
            var result = await _courseService.GetAllCourses();

            // Assert
            Assert.Same(expectedCourses, result);
        }

        [Fact]
        public async Task AddCourse_Success()
        {
            // Arrange
            Course course = new Course();

            // Act
            await _courseService.AddCourse(course);

            // Assert
            _courseRepositoryMock.Verify(x => x.AddCourse(course), Times.Once);
        }

        [Fact]
        public async Task AddStudentToCourse_Success()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();

            _paymentServiceMock.Setup(x => x.CheckPaymentStatus(student, course)).ReturnsAsync(true);

            // Act
            await _courseService.AddStudentToCourse(student, course);

            // Assert
            _courseRepositoryMock.Verify(x => x.AddStudentToCourse(student, course), Times.Once);
            _notificationServiceMock.Verify(x => x.SendNotification(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task AddStudentToCourse_ThrowsPaymentException()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();

            _paymentServiceMock.Setup(x => x.CheckPaymentStatus(student, course)).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<PaymentException>(async () => await _courseService.AddStudentToCourse(student, course));
        }
    }
}
