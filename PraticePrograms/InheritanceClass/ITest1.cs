namespace InheritanceClass
{
    public interface ITest1
    {
        public int Ad1 { get; set; }
        public abstract void Add(int a,int b);
        
    }
    public interface ITest2:ITest1
    {
        void sub(int a,int b);
    }
    public class Testing
    {
        public void some()
        {
            Console.WriteLine("this class method");
        }
    }
    public class Test:Testing,ITest2
    {
        public void Add(int a,int b)
        {
            Console.WriteLine(a+b);
        }
         public int Ad1 { get; set; }
        public void sub(int a,int b)
        {
            Console.WriteLine(a-b);
        }
    }
}
