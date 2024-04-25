namespace Week05
{
    internal class School
    {
        private List<SchoolClass> Classes = new();

        public School() 
        { 
        }

        public void AddClass(SchoolClass schoolClass)
        {
            Classes.Add(schoolClass);
        }

        public int GetStudentCount()
        {
            var totalStudents = 0;

            foreach (var schoolClass in Classes)
            {
                totalStudents += schoolClass.GetStudentCount();
            }
            return totalStudents;
        }
    }
}
