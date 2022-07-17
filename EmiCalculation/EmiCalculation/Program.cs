// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using EmiCalculation;
Console.WriteLine("Emi Calculator");
Console.WriteLine("Enter How much you want Loan Amount");
long loanAmount=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Interest Rate");
float rateofInterest=Convert.ToSingle(Console.ReadLine());
Console.WriteLine("Enter Number of Years");
long year=Convert.ToInt32(Console.ReadLine());
Calculator.Calculation();