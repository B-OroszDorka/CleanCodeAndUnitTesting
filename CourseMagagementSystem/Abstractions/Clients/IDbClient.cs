using CourseMagagementSystem.Models;

namespace CourseMagagementSystem.Abstractions.Clients
{
    public interface IDbClient
    {
        public Task<Course> GetCourseById(string courseId);
        public Task<List<Course>> GetAllCourses();
        public Task<bool> AddCourse(Course course);
        public Task<bool> AddStudentToCourse(Student student, Course course);

    }
}
