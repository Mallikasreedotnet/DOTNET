namespace EmiCalculation
{
    public class Calculator
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public long LoanAmount { get; set; }

        public int Tenure { get; set; }

        public float RateofInterest { get; set; }


        public static void Calculation(long loanAmount,float rateofInterest,long year)
        {
            float r = rateofInterest / 12 / 100;
            double upperLogic = Math.Pow(1 + rateofInterest, year * 12);
            double EMI = loanAmount * rateofInterest * (upperLogic / (upperLogic - 1));
           
            Console.WriteLine("your emi will be:" + EMI);
            //return EMI;
        }
    }
}
