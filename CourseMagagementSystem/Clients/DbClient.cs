using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Models;
using Microsoft.Extensions.Logging;

namespace CourseMagagementSystem.Clients
{
    public class DbClient : IDbClient
    {
        private readonly ILogger<DbClient> _logger;

        public DbClient(ILogger<DbClient> logger)
        {
            _logger = logger;
        }

        public async Task<bool> AddCourse(Course course)
        {
            var courseId = "";
            try
            {
                courseId = course.GetId();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured when adding course: courseid: {courseId}");
                throw new AddingToDbException($"An error occured when adding course: courseid: {courseId}", ex);
            }
        }

        public async Task<bool> AddStudentToCourse(Student student, Course course)
        {
            var courseId = "";
            var studentName = "";
            try
            {
                courseId = course.GetId();
                studentName = student.GetName();
                await course.AddStudentToCourse(student);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured when adding a stundet to a course: courseid: {courseId}, student's name: {studentName}");
                throw new AddingToDbException($"An error occured when adding a stundet to a course: courseid: {courseId}, student's name: {studentName}", ex);
            }
        }

        public async Task<List<Course>> GetAllCourses()
        {
            try
            {
                return new List<Course>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured when getting all courses");
                throw new GettingFromDbException($"An error occured when getting all courses", ex);
            }
        }

        public async Task<Course> GetCourseById(string courseId)
        {
            try
            {
                return new Course();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured when getting course by id: {courseId}");
                throw new GettingFromDbException($"An error occured when getting course by id: {courseId}", ex);
            }
        }
    }
}
