namespace CourseMagagementSystem.Models
{
    public abstract class Person
    {
        private string Name { get; set; }

        public string GetName()
        {  return Name; }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
