using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Abstractions.Repository;
using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Models;
using CourseMagagementSystem.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CourseMagagementSystem.Tests.Repository
{
    public class CourseRepositoryTest
    {
        private readonly Mock<IDbClient> _dbClientMock = new();
        private readonly Mock<ILogger<CourseRepository>> _loggerMock = new();
        private readonly ICourseRepository _courseRepository;

        public CourseRepositoryTest()
        {
            _courseRepository = new CourseRepository(_dbClientMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetCourseById_Success()
        {
            // Arrange
            string courseId = "123";
            Course expectedCourse = new Course();

            _dbClientMock.Setup(x => x.GetCourseById(courseId)).ReturnsAsync(expectedCourse);

            // Act
            var result = await _courseRepository.GetCourseById(courseId);

            // Assert
            Assert.Same(expectedCourse, result);
        }

        [Fact]
        public async Task GetAllCourses_Success()
        {
            // Arrange
            List<Course> expectedCourses = new List<Course>();

            _dbClientMock.Setup(x => x.GetAllCourses()).ReturnsAsync(expectedCourses);

            // Act
            var result = await _courseRepository.GetAllCourses();

            // Assert
            Assert.Same(expectedCourses, result);
        }

        [Fact]
        public async Task AddCourse_Success()
        {
            // Arrange
            Course course = new Course();

            // Act
            await _courseRepository.AddCourse(course);

            // Assert
            _dbClientMock.Verify(x => x.AddCourse(course), Times.Once);
        }

        [Fact]
        public async Task AddStudentToCourse_Success()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();

            _dbClientMock.Setup(x => x.AddStudentToCourse(student, course)).ReturnsAsync(true);

            // Act
            await _courseRepository.AddStudentToCourse(student, course);

            // Assert
            _dbClientMock.Verify(x => x.AddStudentToCourse(student, course), Times.Once);
        }

        [Fact]
        public async Task AddStudentToCourse_IfStudentNull_ThrowsAddingToDbException()
        {
            // Arrange
            Student student = null;
            var course = new Course();
            _dbClientMock.Setup(x => x.AddStudentToCourse(student, course)).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<AddingToDbException>(async () => await _courseRepository.AddStudentToCourse(student, course));
        }

        [Fact]
        public async Task AddStudentToCourse_IfCourseNull_ThrowsAddingToDbException()
        {
            // Arrange
            var student = new Student("Jack Doe");
            Course course = null;
            _dbClientMock.Setup(x => x.AddStudentToCourse(student, course)).ReturnsAsync(false);

            // Act & Assert
            await Assert.ThrowsAsync<AddingToDbException>(async () => await _courseRepository.AddStudentToCourse(student, course));
        }
    }
}
