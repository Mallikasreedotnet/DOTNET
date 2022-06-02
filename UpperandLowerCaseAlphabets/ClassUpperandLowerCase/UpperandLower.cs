namespace ClassUpperandLowerCase
{
    public class UpperandLower
    {
      public static void Alphabets(char ch)
        {
           
            if(ch>= 'a' && ch<='z')
            {
              Console.WriteLine($"This is lowercase alphabet : {ch}");
            }
            else if(ch>= 'A' && ch<='Z')
            {
                Console.WriteLine($"This is uppercase alphabet : {ch}");
            }
            else
            {
                Console.WriteLine($"This not a alphabet : {ch}");
            }
        }
    }
}