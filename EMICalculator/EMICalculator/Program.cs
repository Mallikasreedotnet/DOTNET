// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using EMICalculator;
Console.Write("Enter The Loan Amount : ");
long Amount = Convert.ToInt32(Console.ReadLine());
Calculator.Calculation(Amount);
Console.Write("Enter How many months of emi : ");
int Months = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"You Pay Every Month Amount is : {Calculator.MonthlyEmi(Amount , Months)}  ");
