namespace InheritanceClass
{
    public class AccessModifiers
    {
        public void Test()
        {
            Console.WriteLine("this test method");
        }
        ~AccessModifiers()
        {
            Console.WriteLine("This is parent destructor method");
        }
        
    }
    public class Chlid : AccessModifiers
    {
        public void Test1()
        {
            Console.WriteLine("this test1 method");
        }
        ~Chlid()
        {
            Console.WriteLine("This is child destructor method");
        }
    }
}
