using CourseMagagementSystem.Clients;
using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CourseManagementSystemTests.Clients
{
    public class DbClientTest
    {
        private readonly Mock<ILogger<DbClient>> _loggerMock = new();
        private readonly DbClient _dbClient;

        public DbClientTest()
        {
            _loggerMock.Setup(x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<DbClient>(),
                It.IsAny<Exception>(),
                (Func<object, Exception, string>)It.IsAny<object>()));

            _dbClient = new DbClient(_loggerMock.Object);
        }

        [Fact]
        public async Task AddCourse_Success()
        {
            // Arrange
            var course = new Course();

            // Act
            var result = await _dbClient.AddCourse(course);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddCourse_IfCourseNull_ThrowsAddingToDbException()
        {
            // Arrange
            Course course = null;

            // Act & Assert
            await Assert.ThrowsAsync<AddingToDbException>(async () => await _dbClient.AddCourse(course));
        }

        [Theory]
        [InlineData("C001")]
        [InlineData("C002")]
        public async Task GetCourseById_Parameterized(string courseId)
        {
            // Arrange

            // Act
            var result = await _dbClient.GetCourseById(courseId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Course>(result);
        }

        [Fact]
        public async Task AddStudentToCourse_Success()
        {
            // Arrange
            var student = new Student("John Doe");
            var course = new Course();

            // Act
            var result = await _dbClient.AddStudentToCourse(student, course);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddStudentToCourse_IfStudentNull_ThrowsAddingToDbException()
        {
            // Arrange
            Student student = null;
            var course = new Course();

            // Act & Assert
            await Assert.ThrowsAsync<AddingToDbException>(async () => await _dbClient.AddStudentToCourse(student, course));
        }

        [Fact]
        public async Task GetAllCourses_Success()
        {
            // Arrange

            // Act
            var result = await _dbClient.GetAllCourses();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Course>>(result);
            Assert.Empty(result);
        }
    }
}
