using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMagagementSystem.Models
{
    public class Course
    {
        private string CourseId {  get; set; }
        private List<Student> StudentList = new();

        public string GetId()
        { return CourseId; }

        public async Task AddStudentToCourse(Student student)
        {
            StudentList.Add(student);
        }

        public async Task<List<Student>> GetStudents()
        {
            return StudentList;
        }
    }
}
