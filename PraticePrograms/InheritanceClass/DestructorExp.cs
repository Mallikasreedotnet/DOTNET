namespace InheritanceClass
{
    public class DestructorExp
    {
        public string Name;
        public int Age;

        public DestructorExp(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string getName()
        {
            return this.Name;
        }
        public int getAge()
        {
            return this.Age;
        }
        ~DestructorExp()
        {
            Console.WriteLine("Destructor method");
        }
    }
}
