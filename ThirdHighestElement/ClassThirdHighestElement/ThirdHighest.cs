namespace ClassThirdHighestElement
{
    public class ThirdHighest
    {
      public static void Elements()
        {
            int  i, first=0,second=0, third=0;
            int[] arr = new int[50];
           int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter elements in the array : {num}");
            //Console.WriteLine($"Enter {0} elements in the array : {num}");
            for (i = 0; i < num; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            
            if(arr[i] > first)
                {
                    third = second;
                    second = first;
                    first = arr[i];
                }
            else if (arr[i]>second)
                {
                    third = second;
                    second=arr[i];
                }
            else if (arr[i]>third)
                {
                    third=arr[i];
                }
          
            }
            Console.WriteLine($"This is the third highest number in the array : {third}");
        }

    }
}