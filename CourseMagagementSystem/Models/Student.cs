namespace CourseMagagementSystem.Models
{
    public class Student : Person
    {
        public Student(string name)
        {
            this.SetName(name);
        }
        private List<Course> RegisteredCourses = new();
    }
}
