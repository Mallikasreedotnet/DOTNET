namespace InheritanceClass
{
    public class Example1
    {
       public int EmpId;
       public string EmpName;
       public int EmpSalary;
        public static string CompanyName;
        public Example1(int EmpId, string EmpName, int EmpSalary)
        {
            this.EmpId = EmpId;
            this.EmpName = EmpName;
            this.EmpSalary = EmpSalary;
        }

        static Example1()
        {
            Console.WriteLine("Static constructor");
            CompanyName = "QUALMINDS";
            
        }
        public Example1(Example1 e)
        {
            this.EmpId = e.EmpId;
            this.EmpName = e.EmpName;
            this.EmpSalary = e.EmpSalary;
           
        }
    }
}
