namespace Week05
{
    internal class SchoolClass
    {
        private List<Student> Students = new();
        public SchoolClass() 
        {
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public int GetStudentCount()
        {
            return Students.Count;
        }
    }
}
