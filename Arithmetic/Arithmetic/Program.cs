// See https://aka.ms/new-console-template for more information
using ArithmeticOperators;
{
    Console.WriteLine("Enter any number");
    int i = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter which arithmetic operator you want : +,-,*,/,% ");
    char j = Convert.ToChar(Console.ReadLine());
    Console.WriteLine("Enter any number");
    int k = Convert.ToInt32(Console.ReadLine());
    try
    {
        Console.WriteLine("Result: " + Operator.Operations(i, j, k));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message.ToString());
    }
}