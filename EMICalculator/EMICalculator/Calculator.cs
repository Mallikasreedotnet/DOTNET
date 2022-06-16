using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMICalculator
{
    public class Calculator
    {
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

        }
}
