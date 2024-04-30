using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Abstractions.Repository;
using CourseMagagementSystem.Exceptions;
using CourseMagagementSystem.Models;
using Microsoft.Extensions.Logging;

namespace CourseMagagementSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbClient _dbClient;
        private readonly ILogger<CourseRepository> _logger;

        public CourseRepository(IDbClient dbClient, ILogger<CourseRepository> logger)
        {
            _dbClient = dbClient;
            _logger = logger;
        }

        public async Task<Course> GetCourseById(string courseId)
        {
            return await _dbClient.GetCourseById(courseId);
        }
        public async Task<List<Course>> GetAllCourses()
        {
            return await _dbClient.GetAllCourses();
        }
        public async Task AddCourse(Course course)
        {
            await _dbClient.AddCourse(course);
        }
        public async Task AddStudentToCourse(Student student, Course course)
        {
            if(student == null || course == null)
            {
                throw new AddingToDbException($"Student couldn't be added to course!");
            }

            var courseId = course.GetId();
            
            var studentToCourseAddingStatus = await _dbClient.AddStudentToCourse(student, course);
            if (!studentToCourseAddingStatus)
            {
                _logger.LogError($"Student couldn't be added to course with id: {courseId}!");
                throw new AddingToDbException($"Student couldn't be added to course with id: {courseId}!");
            }

        }
    }
}
