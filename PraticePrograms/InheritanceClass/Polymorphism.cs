namespace InheritanceClass
{
    public class Polymorphism
    {
        public void some()
        {
            Console.WriteLine("this is a parent class methodes");
        }
    }
    public class child : Polymorphism
        {
        public new void some()
    {
            //base.some();
            Console.WriteLine("this is a child class");
        }
        }
}

