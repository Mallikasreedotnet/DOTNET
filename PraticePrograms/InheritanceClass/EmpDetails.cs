namespace InheritanceClass
{
    public class EmpDetails
    {
        public int EmpId;
        public string EmpName;
        public string EmpDesc;
        public EmpDetails(string message)
        {
            Console.WriteLine(message);
        }
            
        public void show() { 
        Console.WriteLine("This is a base class");
        }
    }
    public class VisitingEmp : EmpDetails
    {
        public int VisitingSalary;
        public int VisitingHours;
        public VisitingEmp():base("hello")
        {
            Console.WriteLine("this is visiting class constructor");
        }
    }
    //public class PermanentEmp : EmpDetails 
    //{
    //    public int PermanentSalary;
    //    public int PermanentHours;
    //}
}
