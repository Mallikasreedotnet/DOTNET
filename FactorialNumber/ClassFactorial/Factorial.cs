﻿namespace ClassFactorial
{
    public class Factorial
    {
        public static void FactNumber(int num)
        {
            int i, f=1;
            for(i=1;i<=num;i++)
            {
                f=f*i;
            }
            Console.WriteLine($"Factorial : {f} ");
        }
             
    }
}