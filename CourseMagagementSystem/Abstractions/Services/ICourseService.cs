using CourseMagagementSystem.Models;

namespace CourseMagagementSystem.Abstractions.Services
{
    public interface ICourseService
    {
        public Task<Course> GetCourseById(string courseId);
        public Task<List<Course>> GetAllCourses();
        public Task AddCourse(Course course);

        public Task AddStudentToCourse(Student student, Course course);
    }
}
