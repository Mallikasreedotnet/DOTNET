using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMICalculator
{
    public class Calculator
    {
        public string Name { get; set; }
        
        //public DateTime LastDate { get; set; }

        public string Address { get; set; }

        public string Licence { get; set; }

        public int Amount { get; set; }

        public decimal TotalAmount { get; set; }

        public Calculator(string name, string address,string licence)
        {
            Name= name;
            Address= address;
           
               Licence= licence;
            Amount= 0;
            TotalAmount= 0;
        }
       

        public static void Calculation(long Amount)
        {
            float Percentage = (Amount / 100)*5;
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"{i}  month You Pay Amount is  : {(Amount + (Percentage * i)) / i}");
            }
        }
        public static long MonthlyEmi(long Amount, int Months)
        {
            long percentage = (Amount / 100) * 5;
            long Totalamount = Amount + (percentage * Months);
            long Monthpay = Totalamount / Months;
            return Monthpay;
         }
       

        public int Months { get; set; }

        

        }
}
