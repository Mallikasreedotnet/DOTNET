namespace Multiplication
{
    public class Table
    {
       

        public static void Multiplication(int num)
        {
            int i;
            
            for (i = 1; i <= 20; i++)
            {
               Console.WriteLine($"{num} * {i} = {num*i}");
            }
        }
    }
}