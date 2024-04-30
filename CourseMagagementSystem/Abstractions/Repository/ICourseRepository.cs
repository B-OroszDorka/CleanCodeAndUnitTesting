using CourseMagagementSystem.Models;

namespace CourseMagagementSystem.Abstractions.Repository
{
    public interface ICourseRepository
    {
        public Task<Course> GetCourseById(string courseId);
        public Task<List<Course>> GetAllCourses();
        public Task AddCourse(Course course);
        public Task AddStudentToCourse(Student student, Course course);
    }
}
