namespace InheritanceClass
{
    public class Employee
    {
       
        public string Name { get; }

        public decimal basepay;

        public Employee(string name, decimal basepay)
        {
            Name = name;
            this.basepay = basepay;
        }

        public virtual decimal Calculatepay()
        {
            return basepay;
        }
    }

    public class SalesEmployee : Employee
    {
        private decimal salesbonus;

        public SalesEmployee(string name,decimal basepay, decimal salesbonus) : base(name,basepay)
        {
            this.salesbonus = salesbonus;
        }

        public override decimal Calculatepay()
        {
            return basepay+salesbonus;
        }
        
    }
}